using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.AI;

public interface INavMeshMovable : IUnitMovable
{
    public ReactiveProperty<float> Speed { get; set; }

    public float MoveRate { get; set; }
    public float DistanceToStop { get; set; }
    public NavMeshAgent NavMeshAgent { get; set; }
}
