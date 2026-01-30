using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class NavMeshUnitAnimationChangeHandler : NavMeshUnitActionHandler
{
    public NavMeshUnitAnimationChangeHandler(DiContainer container, ReactiveProperty<NavMeshUnitMovementHandler> navMeshUnitMovementHandler, UnitProduct unitProduct) : base(container, navMeshUnitMovementHandler, unitProduct)
    {
        cooldown = 1;
    }

    public override void OnUnitNotRight()
    {
        ownProduct.StartCoroutine(CallWithDefaultCooldown());
    }

    public override void OnDestinationReached()
    {
        Dispose();
        ActionCall?.Invoke();
    }

    public override event Action ActionCall;

    private IEnumerator CallWithDefaultCooldown()
    {
        yield return new WaitForSeconds(0.1f);
        navMeshUnitMovementHandler.Value.DestinationReached += OnDefaultDestinationReached;
    }

    private void OnDefaultDestinationReached()
    {
        ActionCall?.Invoke();
    }
}
