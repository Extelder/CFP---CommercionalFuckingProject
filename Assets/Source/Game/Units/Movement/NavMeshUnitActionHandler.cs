using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public abstract class NavMeshUnitActionHandler : INavMeshActionCallable ,IDisposable
{
    [Inject] private IQueueActionCallable<CustomerUnitProduct> _customerUnitProductQueue;
    protected UnitProduct ownProduct;
    protected ReactiveProperty<NavMeshUnitMovementHandler> navMeshUnitMovementHandler;
    protected float cooldown;

    private CompositeDisposable _disposable = new CompositeDisposable();

    public NavMeshUnitActionHandler(DiContainer container,
        ReactiveProperty<NavMeshUnitMovementHandler> navMeshUnitMovementHandler, UnitProduct unitProduct)
    {
        ownProduct = unitProduct;
        container.Inject(this);
        this.navMeshUnitMovementHandler = navMeshUnitMovementHandler;
        _customerUnitProductQueue.UnitActionCallable += OnUnitCanGetAction;
    }

    private void OnUnitCanGetAction(UnitProduct firstUnitProduct)
    {
        if (firstUnitProduct == ownProduct)
        {
            navMeshUnitMovementHandler.Subscribe(_ =>
            {
                if (_ == null)
                {
                    _disposable.Clear();
                    return;
                }

                ownProduct.StartCoroutine(CallWithCooldown(_));
            }).AddTo(_disposable);
            return;
        }
        OnUnitNotRight();
    }

    public abstract void OnUnitNotRight();

    public abstract void OnDestinationReached();

    private IEnumerator CallWithCooldown(NavMeshUnitMovementHandler navMeshUnitMovementHandler)
    {
        yield return new WaitForSeconds(cooldown);
        navMeshUnitMovementHandler.DestinationReached += OnDestinationReached;
    }

    public void Dispose()
    {
        _customerUnitProductQueue.UnitActionCallable -= OnUnitCanGetAction;
        navMeshUnitMovementHandler?.Dispose();
        _disposable.Dispose();
    }

    public abstract event Action ActionCall;
}