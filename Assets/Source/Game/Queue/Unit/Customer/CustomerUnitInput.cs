using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class CustomerUnitInput : IUnitInput
{
    private CompositeDisposable _disposable = new CompositeDisposable();

    public CustomerUnitInput(Vector3 targetPoint)
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                MoveInputDrag?.Invoke(targetPoint);
            }
        }).AddTo(_disposable);
    }
    
    public void Dispose()
    {
        _disposable.Clear();
    }

    public event Action<Vector2> MoveInputDrag;
    public event Action<Vector2> RotateInputDrag;
}
