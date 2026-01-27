using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UniRx;
using UnityEngine;
using Zenject;

public class PlayerUnitCutDownHandler : UnitActionHandler
{
    private IPlayerUnitCutDownInput _cutDownInput;

    private float _currentValue;

    private Tween _shakeTween;

    private CompositeDisposable _disposable;

    private ResourceContainer _resourceContainer;

    public PlayerUnitCutDownHandler(IPlayerUnitCutDownInput unitActionInput, CompositeDisposable disposable,
        ResourceContainer resourceContainer, PlayerCutDownConfig config) : base(
        unitActionInput)
    {
        _currentValue = config.CutDownSpeed;
        _resourceContainer = resourceContainer;
        _cutDownInput = unitActionInput;
        _disposable = disposable;
    }

    protected override void OnActionStarted()
    {
        Observable.Interval(TimeSpan.FromSeconds(_currentValue)).Subscribe(_ =>
        {
            _resourceContainer.TryAdd(1, _cutDownInput.Resource);
            _shakeTween = _cutDownInput.Tree.transform.DOShakeScale(1, 1);
        }).AddTo(_disposable);
    }

    protected override void OnActionStopped()
    {
        _disposable.Clear();
        _shakeTween?.Kill();
    }
}