using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class UnitProduct : AbstactProduct, INavMeshMovable, IUnitTransformable
{
    public float Speed { get; set; }
    [field: SerializeField] public float MoveRate { get; set; }
    [field: SerializeField] public float DistanceToStop { get; set; }
    [field: SerializeField] public NavMeshAgent NavMeshAgent { get; set; }
    [field: SerializeField] public Transform Transform { get; set; }
 
    private Transform _targetPoint;
    private CustomerUnitInput _input;
    private CustomerUnitMovementHandler _movementHandler;
    
    [Inject]
    public void Construct(UnitConfig config)
    {
        Speed = config.Speed;
    }
    
    public override void Init()
    {
        Initialized?.Invoke();
    }

    public void Move(Transform targetPoint)
    {
        _targetPoint = targetPoint;
        CustomerUnitInput input = new CustomerUnitInput(_targetPoint);
        _input = input;
        CustomerUnitMovementHandler movementHandler = new CustomerUnitMovementHandler(_input, this);
        _movementHandler = movementHandler;
    }

    public override event Action Initialized;
}
