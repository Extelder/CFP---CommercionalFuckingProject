using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class NavMeshUnitAnimationChangeHandler : IAnimationChangable, IDisposable
{
    [Inject] private IQueueKillable<CustomerUnitProduct> _customerUnitProductQueue;
    private UnitProduct _ownProduct;
    private CompositeDisposable _disposable = new CompositeDisposable();
    private ReactiveProperty<NavMeshUnitMovementHandler> _navMeshUnitMovementHandler;
    public NavMeshUnitAnimationChangeHandler(DiContainer container,
        ReactiveProperty<NavMeshUnitMovementHandler> navMeshUnitMovementHandler, UnitProduct unitProduct)
    {
        _ownProduct = unitProduct;
        container.Inject(this);
        _customerUnitProductQueue.UnitCanBeKilled += OnUnitCanBeKilled;
        _navMeshUnitMovementHandler = navMeshUnitMovementHandler;
    }

    private void OnUnitCanBeKilled(UnitProduct firstUnitProduct)
    {
        if (firstUnitProduct == _ownProduct)
        {
            _navMeshUnitMovementHandler.Subscribe(_ =>
            {
                if (_ == null)
                {
                    _disposable.Clear();
                    return;
                }
                
                _ownProduct.StartCoroutine(CallWithCooldown(_));
            }).AddTo(_disposable);
            return;
        }
        _ownProduct.StartCoroutine(CallWithCooldownFF());
    }

    private void OnDefaultDestinationReached()
    {
        AnimationChange?.Invoke();
    }

    private void OnDestinationReached()
    {
        Dispose();
        AnimationChange?.Invoke();
    }

    private IEnumerator CallWithCooldown(NavMeshUnitMovementHandler navMeshUnitMovementHandler)
    {
        yield return new WaitForSeconds(1);
        navMeshUnitMovementHandler.DestinationReached += OnDestinationReached;
    }
    
    private IEnumerator CallWithCooldownFF()
    {
        yield return new WaitForSeconds(0.1f);
        _navMeshUnitMovementHandler.Value.DestinationReached += OnDefaultDestinationReached;
    }

    public void Dispose()
    {
        _navMeshUnitMovementHandler.Value.DestinationReached -= OnDestinationReached;
        _navMeshUnitMovementHandler.Value.DestinationReached -= OnDefaultDestinationReached;
        _customerUnitProductQueue.UnitCanBeKilled -= OnUnitCanBeKilled;
        _disposable.Clear();
    }

    public event Action AnimationChange;
}
