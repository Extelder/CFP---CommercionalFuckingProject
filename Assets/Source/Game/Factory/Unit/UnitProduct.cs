using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class UnitProduct : AbstractProduct, INavMeshMovable, IUnitTransformable, IUnitInput, IUnitDeathable
{
    public float Speed { get; set; }
    [field: SerializeField] public float MoveRate { get; set; }
    [field: SerializeField] public float DistanceToStop { get; set; }
    [field: SerializeField] public NavMeshAgent NavMeshAgent { get; set; }
    [field: SerializeField] public Transform Transform { get; set; }

    private Transform _targetPoint;
    private NavMeshUnitMovementHandler _navMeshUnitMovementHandler;
    private ReactiveProperty<IUnitKillable> _unitKillable = new ReactiveProperty<IUnitKillable>();
    private UnitDeathHandler _unitDeathHandler;

    [Inject]
    public void Construct(UnitConfig config)
    {
        Speed = config.Speed;

        _unitDeathHandler = new UnitDeathHandler(this, _unitKillable);
    }

    public override void Init()
    {
        Initialized?.Invoke();
    }

    public void Move(Vector3 targetPoint)
    {
        CreateNewClassExamples(targetPoint);
    }

    private void CreateNewClassExamples(Vector3 targetPoint)
    {
        _navMeshUnitMovementHandler?.Dispose();
        _navMeshUnitMovementHandler = new NavMeshUnitMovementHandler(this, this);
        _unitKillable.Value = _navMeshUnitMovementHandler;
        MoveInputDrag?.Invoke(targetPoint);
    }

    public override event Action Initialized;
    public event Action<Vector3> MoveInputDrag;
    public event Action<Vector2> RotateInputDrag;

    public void Dispose()
    {
        _navMeshUnitMovementHandler?.Dispose();
        _unitKillable?.Dispose();
        _unitDeathHandler?.Dispose();
    }

    public void Death()
    {
        Debug.Log("CAN DIE");
        if (!CanDie)
            return;
        Debug.Log("CAN DIE REALLY");
        Destroy(gameObject);
    }

    public bool CanDie { get; set; }
}