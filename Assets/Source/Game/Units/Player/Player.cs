using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IRigidbodyMovable
{
    public float Speed { get; set; }

    [field: SerializeField] public Rigidbody Rigidbody { get; set; }

    [Inject]
    public void Construct(PlayerConfig config)
    {
        Speed = config.Speed;
    }
}