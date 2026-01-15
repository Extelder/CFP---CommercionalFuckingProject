using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IRigidbodyMovable, IUnitTransformable
{
    public float Speed { get; set; }
    [field: SerializeField] public Rigidbody Rigidbody { get; set; }
    [field: SerializeField] public Animator Animator { get; set; }

    private CompositeDisposable _disposable = new CompositeDisposable();

    private PlayerAnimator _animator;

    [Inject]
    public void Construct(PlayerConfig config, IUnitInput playerInput)
    {
        Speed = config.MoveSpeed;
        _disposable = new CompositeDisposable();
        _animator = new PlayerAnimator(Animator, playerInput, _disposable);
    }

    private void OnDisable()
    {
        _disposable.Clear();
        _animator.Dispose();
    }

    [field: SerializeField] public Transform Transform { get; set; }
}