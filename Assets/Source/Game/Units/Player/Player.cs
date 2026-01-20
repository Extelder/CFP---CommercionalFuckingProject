using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IRigidbodyMovable, IUnitTransformable, IUnitActionProvider
{
    [field: SerializeField] public ResourceContainer ResourceContainer { get; private set; }

    public float Speed { get; set; }
    [field: SerializeField] public Rigidbody Rigidbody { get; set; }
    [field: SerializeField] public Animator Animator { get; set; }

    private CompositeDisposable _disposable = new CompositeDisposable();

    private PlayerAnimator _animator;

    private PlayerUnitCutDownHandler _cutDownHandler;
    private PlayerUnitCutDownAnimatorHandler _playerUnitCutDownAnimatorHandler;

    [Inject]
    public void Construct(PlayerConfig config, IUnitInput playerInput)
    {
        Speed = config.MoveSpeed;
        _disposable = new CompositeDisposable();
        _animator = new PlayerAnimator(Animator, playerInput, _disposable);

        ResourceContainerView containerView =
            new ResourceContainerView(ResourceContainer, ResourceContainer.SpawnPoint);
    }

    private void OnDisable()
    {
        _disposable.Clear();
        _animator.Dispose();
    }

    [field: SerializeField] public Transform Transform { get; set; }

    public void Provide(IPlayerUnitCutDownInput playerUnitCutDownInput)
    {
        _cutDownHandler?.Dispose();
        _playerUnitCutDownAnimatorHandler?.Dispose();

        _cutDownHandler =
            new PlayerUnitCutDownHandler(playerUnitCutDownInput, new CompositeDisposable(), ResourceContainer);

        _playerUnitCutDownAnimatorHandler =
            new PlayerUnitCutDownAnimatorHandler(playerUnitCutDownInput, _animator, _animator);
    }
}