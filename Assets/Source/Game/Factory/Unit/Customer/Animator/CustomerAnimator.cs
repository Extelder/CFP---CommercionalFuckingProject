using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CustomerAnimator : UnitAnimator, IMoveUnitAnimatorInput, IDisposable
{
    private IUnitInput _customerInput;
    private IAnimationChangable _animationChangable;
    
    public CustomerAnimator(Animator animator, IUnitInput customerInput, CompositeDisposable disposable, IAnimationChangable animationChangable) : base(animator)
    {
        CustomerUnitMovementAnimatorHandler unitMovementAnimatorHandler = new CustomerUnitMovementAnimatorHandler(this, this, disposable);
        _customerInput = customerInput;
        _customerInput.MoveInputDrag += OnMoveInputDragged;
        _animationChangable = animationChangable;
        _animationChangable.AnimationChange += OnAnimationChange;
    }

    private void OnAnimationChange()
    {
        Moving.Value = false;
        Debug.Log("FALSE MOVE");
    }

    private void OnMoveInputDragged(Vector3 value)
    {
        Moving.Value = value.sqrMagnitude > 0;
    }

    public ReactiveProperty<bool> Moving { get; set; } = new ReactiveProperty<bool>();
    public string MovingBoolName { get; set; } = "Run";
    public void Dispose()
    {
        _customerInput.MoveInputDrag -= OnMoveInputDragged;
        _animationChangable.AnimationChange -= OnAnimationChange;
    }
}
