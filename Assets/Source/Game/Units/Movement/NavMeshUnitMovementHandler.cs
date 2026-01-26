using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class NavMeshUnitMovementHandler : UnitMovementHandler
{
    private CompositeDisposable _disposable = new CompositeDisposable();
    protected INavMeshMovable navMeshMovable;

    public event Action DestinationReached;

    public NavMeshUnitMovementHandler(IUnitInput unitInput, INavMeshMovable navMeshMovable) : base(unitInput)
    {
        this.navMeshMovable = navMeshMovable;
        this.navMeshMovable.NavMeshAgent.speed = this.navMeshMovable.Speed;
    }

    public override void OnMoveUnitInputReceived(Vector3 value)
    {
        _disposable.Clear();
        Observable.Interval(TimeSpan.FromSeconds(navMeshMovable.MoveRate)).Subscribe(_ =>
        {
            navMeshMovable.NavMeshAgent.SetDestination(value);
            if (navMeshMovable.NavMeshAgent.remainingDistance < navMeshMovable.DistanceToStop)
            {
                Debug.Log("DESTINATION REACHED");
                DestinationReached?.Invoke();
            }
        }).AddTo(_disposable);
    }

    public override void Dispose()
    {
        base.Dispose();
        _disposable.Clear();
    }
}
