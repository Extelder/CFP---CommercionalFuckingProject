using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ShopBuyerInput : IUnitInput
{
    private CompositeDisposable _disposable = new CompositeDisposable();
    
    public ShopBuyerInput(Vector3 targetPoint)
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                MoveInputDrag?.Invoke(targetPoint);
            }
        }).AddTo(_disposable);
    }
    
    public void Dispose()
    {
        _disposable.Clear();
    }

    public event Action<Vector3> MoveInputDrag;
    public event Action<Vector2> RotateInputDrag;
}
