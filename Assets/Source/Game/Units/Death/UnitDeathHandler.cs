using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class UnitDeathHandler : IDisposable
{
    private INavMeshActionCallable _unitKillable;
    private IUnitDeathable _unitDeathable;
    private CompositeDisposable _disposable = new CompositeDisposable();
    
    public UnitDeathHandler(IUnitDeathable unitDeathable, ReactiveProperty<INavMeshActionCallable> actionCallable)
    {
        actionCallable.Subscribe(_ =>
        {
            if (_ == null)
            {
                return;
            }

            _unitDeathable = unitDeathable;
            _unitKillable = _;
            _unitKillable.ActionCall += OnUnitKill;
            Debug.Log("SUBSCRIBE");
        }).AddTo(_disposable);
    }

    private void OnUnitKill()
    {
        Debug.Log("SUBSCRIBED");
        _unitDeathable.Death();
    }

    public void Dispose()
    {
        _unitKillable.ActionCall -= OnUnitKill;
        _disposable.Clear();
    }
}
