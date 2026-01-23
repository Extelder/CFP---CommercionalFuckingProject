using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CustomerUnitMovementAnimatorHandler
{
    public CustomerUnitMovementAnimatorHandler(IMoveUnitAnimatorInput animatorInput, UnitAnimator animator, CompositeDisposable disposable)
    {
        animatorInput.Moving.Subscribe(_ => { animator.Animator.SetBool(animatorInput.MovingBoolName, _); }).AddTo(disposable);
    }
}
