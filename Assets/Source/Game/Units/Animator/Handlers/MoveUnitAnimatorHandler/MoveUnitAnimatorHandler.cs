using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class MoveUnitAnimatorHandler
{
        public MoveUnitAnimatorHandler(IMoveUnitAnimatorInput input, UnitAnimator animator, CompositeDisposable disposable)
        {
            input.Moving.Subscribe(_ => { animator.Animator.SetBool(input.MovingBoolName, _); }).AddTo(disposable);
        }
}