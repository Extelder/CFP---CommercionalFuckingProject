using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerAnimator : UnitAnimator, IMoveUnitAnimatorInput, IDisposable, IUnitCutDownAnimatorInput
{
    private IUnitInput _playerInput;

    public PlayerAnimator(Animator animator, IUnitInput playerInput, CompositeDisposable disposable) : base(animator)
    {
        MoveUnitAnimatorHandler unitAnimatorHandler = new MoveUnitAnimatorHandler(this, this, disposable);

        _playerInput = playerInput;
        _playerInput.MoveInputDrag += OnMoveInputDragged;
    }

    private void OnMoveInputDragged(Vector3 value)
    {
        Moving.Value = value.sqrMagnitude > 0;
    }

    public ReactiveProperty<bool> Moving { get; set; } = new ReactiveProperty<bool>();
    public string MovingBoolName { get; set; } = "IsMoving";
    public string CuttingDownBoolName { get; set; } = "IsCuttingDown";

    public void Dispose()
    {
        _playerInput.MoveInputDrag -= OnMoveInputDragged;
    }
}