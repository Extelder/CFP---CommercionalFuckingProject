using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class NavMeshUnitKillHandler : IUnitKillable, IDisposable
{
    [Inject] private IQueueKillable<CustomerUnitProduct> _customerUnitProductQueue;
    private UnitProduct _ownProduct;
    private CompositeDisposable _disposable = new CompositeDisposable();
    private ReactiveProperty<NavMeshUnitMovementHandler> _navMeshUnitMovementHandler;
    public NavMeshUnitKillHandler(DiContainer container,
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
            Debug.Log("KILL SUKA");
            _navMeshUnitMovementHandler.Subscribe(_ =>
            {
                if (_ == null)
                {
                    _disposable.Clear();
                    return;
                }

                _ownProduct.StartCoroutine(CallWithCooldown(_));
            }).AddTo(_disposable);
        }
    }
    
    private void OnDestinationReached()
    {
        Debug.Log("DESTINATION REACHED");
        Dispose();
        UnitKill?.Invoke();
    }

    private IEnumerator CallWithCooldown(NavMeshUnitMovementHandler navMeshUnitMovementHandler)
    {
        yield return new WaitForSeconds(1);
        Debug.Log("SUBSCRIBE");
        navMeshUnitMovementHandler.DestinationReached += OnDestinationReached;
    }

    public event Action UnitKill;

    public void Dispose()
    {
        _navMeshUnitMovementHandler.Value.DestinationReached -= OnDestinationReached;
        _customerUnitProductQueue.UnitCanBeKilled -= OnUnitCanBeKilled;
        _disposable.Clear();
    }
}