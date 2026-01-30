using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SettingsInput : IKeyInput, IDisposable
{
    private SettingsConfig _config;
    private CompositeDisposable _disposable = new CompositeDisposable();
    
    public SettingsInput(SettingsConfig config)
    {
        _config = config;
        CheckOnKey();
    }

    private void CheckOnKey()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (Input.GetKeyDown(_config.PressKey))
            {
                KeyPressed?.Invoke();
            }
        }).AddTo(_disposable);
    }

    public event Action KeyPressed;

    public void Dispose()
    {
        _disposable.Clear();
    }
}
