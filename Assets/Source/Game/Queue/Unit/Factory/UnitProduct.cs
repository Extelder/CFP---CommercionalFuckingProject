using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class UnitProduct : AbstactProduct, INavMeshMovable, IUnitTransformable, IUnitInput
{
    public float Speed { get; set; }
    public int NeededResources { get; set; }
    [field: SerializeField] public float MoveRate { get; set; }
    [field: SerializeField] public float DistanceToStop { get; set; }
    [field: SerializeField] public NavMeshAgent NavMeshAgent { get; set; }
    [field: SerializeField] public Transform Transform { get; set; }
    public event Action Bought;
 
    private Transform _targetPoint;
    private CustomerUnitMovementHandler _customerUnitMovementHandler;
    
    [Inject]
    public void Construct(UnitConfig config)
    {
        Speed = config.Speed;
        NeededResources = config.NeededRecources;
    }
    
    public override void Init()
    {
        Initialized?.Invoke();
    }

    public void Buy()
    {
        Debug.Log("unitBuy");
        Bought?.Invoke();
    }

    public void Move(float offset)
    {
        CreateNewClassExamples(Transform.position + new Vector3(offset, 0, 0));
    }
    
    public void Move(Vector3 targetPoint)
    {
        CreateNewClassExamples(targetPoint);
    }
    
    private void CreateNewClassExamples(Vector3 targetPoint)
    {
        _customerUnitMovementHandler?.Dispose();
        _customerUnitMovementHandler = new CustomerUnitMovementHandler(this, this);
        MoveInputDrag?.Invoke(targetPoint);
    }

    public override event Action Initialized;
    public void Dispose()
    {
    }

    public event Action<Vector3> MoveInputDrag;
    public event Action<Vector2> RotateInputDrag;
}
