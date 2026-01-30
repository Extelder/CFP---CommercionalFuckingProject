using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class NavMeshUnitKillHandler : NavMeshUnitActionHandler
{
    public NavMeshUnitKillHandler(DiContainer container, ReactiveProperty<NavMeshUnitMovementHandler> navMeshUnitMovementHandler, UnitProduct unitProduct) : base(container, navMeshUnitMovementHandler, unitProduct)
    {
        cooldown = 1;
    }

    public override void OnUnitNotRight()
    {}

    public override void OnDestinationReached()
    {
        Debug.Log("DESTINATIONREACHED");
        Dispose();
        ActionCall?.Invoke();
    }

    public override event Action ActionCall;
}