using System;
using UniRx;
using UnityEngine;
using Zenject;

public class MobileInput : IInput
{
    public event Action<Vector2> MoveInputDrag;

    private CompositeDisposable _disposable = new CompositeDisposable();

    public MobileInput()
    {
        Debug.Log("I Created Mobile bitch!");

        Observable.EveryUpdate().Subscribe(_ =>
        {
            MoveInputDrag?.Invoke(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }).AddTo(_disposable);
    }

    public void Dispose()
    {
        _disposable.Clear();
    }
}