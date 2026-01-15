using System;
using UniRx;
using UnityEngine;
using Zenject;

public class MobilePlayerInput : IUnitInput
{
    public event Action<Vector2> MoveInputDrag;
    public event Action<Vector2> RotateInputDrag;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private Joystick _joystick;

    [Inject]
    public void Construct(PlayerHUD playerHud)
    {
        _joystick = playerHud.Joystick;
    }

    public MobilePlayerInput()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            MoveInputDrag?.Invoke(new Vector2(_joystick.Horizontal, _joystick.Vertical));
            RotateInputDrag?.Invoke(new Vector2(_joystick.Horizontal, _joystick.Vertical));
        }).AddTo(_disposable);
    }

    public void Dispose()
    {
        _disposable.Clear();
    }
}