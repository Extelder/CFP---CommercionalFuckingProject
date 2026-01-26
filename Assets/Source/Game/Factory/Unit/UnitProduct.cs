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

    private ReactiveProperty<NavMeshUnitMovementHandler> _navMeshUnitMovementHandler =
        new ReactiveProperty<NavMeshUnitMovementHandler>();

    private ReactiveProperty<IUnitKillable> _unitKillable = new ReactiveProperty<IUnitKillable>();
    private UnitDeathHandler _unitDeathHandler;
    private NavMeshUnitKillHandler _unitKillHandler;

    [Inject]
    public void Construct(UnitConfig config, DiContainer container)
    {
        Speed = config.Speed;
        _unitDeathHandler = new UnitDeathHandler(this, _unitKillable);
        _unitKillHandler = new NavMeshUnitKillHandler(container, _navMeshUnitMovementHandler, this);
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
        _navMeshUnitMovementHandler.Value?.Dispose();
        _navMeshUnitMovementHandler.Value = new NavMeshUnitMovementHandler(this, this);
        _unitKillable.Value = _unitKillHandler;
        MoveInputDrag?.Invoke(targetPoint);
    }

    public override event Action Initialized;
    public event Action<Vector3> MoveInputDrag;
    public event Action<Vector2> RotateInputDrag;

    public void Dispose()
    {
        _navMeshUnitMovementHandler.Value?.Dispose();
        _unitKillHandler?.Dispose();
        _unitDeathHandler?.Dispose();
    }

    private void OnDisable()
    {
        Dispose();
    }

    public void Death()
    {
        if (!CanDie)
            return;
        Dispose();
        Destroy(gameObject);
    }

    public bool CanDie { get; set; }
}