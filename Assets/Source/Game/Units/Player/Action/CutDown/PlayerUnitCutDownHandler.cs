using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;

public class PlayerUnitCutDownHandler : UnitActionHandler
{
    private IPlayerUnitCutDownInput _cutDownInput;

    private Tween _shakeTween;

    private CompositeDisposable _disposable;

    public PlayerUnitCutDownHandler(IPlayerUnitCutDownInput unitActionInput, CompositeDisposable disposable) : base(
        unitActionInput)
    {
        _cutDownInput = unitActionInput;
        _disposable = disposable;
    }

    protected override void OnActionStarted()
    {
        Observable.Interval(TimeSpan.FromSeconds(1.5f)).Subscribe(_ =>
        {
            _shakeTween = _cutDownInput.Tree.transform.DOShakeScale(1, 1);
        }).AddTo(_disposable);
    }

    protected override void OnActionStopped()
    {
        _disposable.Clear();
        _shakeTween?.Kill();
    }
}