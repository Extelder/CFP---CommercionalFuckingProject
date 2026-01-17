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
    
    [Inject]
    public void Construct(UnitConfig config)
    {
        Speed = config.Speed;
    }
    
    public override void Init()
    {
        Initialized?.Invoke();
    }

    public void Move(float offset)
    {
        CreateNewExamples(Transform.position + new Vector3(offset, 0, 0));
    }

    public void Move(Vector3 targetPoint)
    {
        CreateNewExamples(targetPoint);
    }

    private void CreateNewExamples(Vector3 targetPoint)
    {
        CustomerUnitInput input = new CustomerUnitInput(targetPoint);
        CustomerUnitMovementHandler movementHandler = new CustomerUnitMovementHandler(input, this);
    }

    public override event Action Initialized;
}
