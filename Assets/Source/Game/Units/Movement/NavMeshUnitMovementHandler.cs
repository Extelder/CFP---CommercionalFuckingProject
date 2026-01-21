using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class NavMeshUnitMovementHandler : UnitMovementHandler
{
    public event Action DestinationReached;
    
    private CompositeDisposable _disposable = new CompositeDisposable();
    protected INavMeshMovable navMeshMovable;
    
    public NavMeshUnitMovementHandler(IUnitInput unitInput, INavMeshMovable navMeshMovable) : base(unitInput)
    {
        this.navMeshMovable = navMeshMovable;
        this.navMeshMovable.NavMeshAgent.speed = this.navMeshMovable.Speed;
    }

    public override void OnMoveUnitInputReceived(Vector3 value)
    {
        Observable.Interval(TimeSpan.FromSeconds(navMeshMovable.MoveRate)).Subscribe(_ =>
        {
            if (navMeshMovable.NavMeshAgent.remainingDistance >= navMeshMovable.DistanceToStop)
            {
                Debug.Log("REACHED DEST");
                DestinationReached?.Invoke();
                _disposable.Clear();
                return;
            }
            navMeshMovable.NavMeshAgent.SetDestination(value);
        }).AddTo(_disposable);
    }

    public override void Dispose()
    {
        base.Dispose();
        _disposable.Clear();
    }
}
