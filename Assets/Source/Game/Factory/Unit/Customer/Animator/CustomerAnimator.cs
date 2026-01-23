using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CustomerAnimator : UnitAnimator, IMoveUnitAnimatorInput, IDisposable
{
    private IUnitInput _customerInput;
    
    public CustomerAnimator(Animator animator, IUnitInput customerInput, CompositeDisposable disposable) : base(animator)
    {
        CustomerUnitMovementAnimatorHandler unitMovementAnimatorHandler = new CustomerUnitMovementAnimatorHandler(this, this, disposable);
        _customerInput = customerInput;
        Debug.Log("CUSTOMER");
        _customerInput.MoveInputDrag += OnMoveInputDragged;
    }

    private void OnMoveInputDragged(Vector3 value)
    {
        Moving.Value = value.sqrMagnitude > 0;
    }

    public ReactiveProperty<bool> Moving { get; set; }
    public string MovingBoolName { get; set; }
    public void Dispose()
    {
        _customerInput.MoveInputDrag -= OnMoveInputDragged;
    }
}
