using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UnitDeathHandler : IDisposable
{
    private IUnitKillable _unitKillable;
    private IUnitDeathable _unitDeathable;
    private CompositeDisposable _disposable = new CompositeDisposable();
    
    public UnitDeathHandler(IUnitDeathable unitDeathable, ReactiveProperty<IUnitKillable> unitKillable)
    {
        unitKillable.Subscribe(_ =>
        {
            if (_ == null)
            {
                return;
            }

            _unitDeathable = unitDeathable;
            _unitKillable = _;
            _unitKillable.UnitKill += OnUnitKill;
        }).AddTo(_disposable);
    }

    private void OnUnitKill()
    {
        _unitDeathable.Death();
    }

    public void Dispose()
    {
        _unitKillable.UnitKill -= OnUnitKill;
        _disposable.Clear();
    }
}
