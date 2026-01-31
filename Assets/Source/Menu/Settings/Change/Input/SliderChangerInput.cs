using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SliderChangerInput : ISettingsChangerInput<float>, IDisposable
{
    private CompositeDisposable _disposable = new CompositeDisposable();
    
    public SliderChangerInput()
    {
        CheckOnInput();
    }

    private void CheckOnInput()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                ValueChanged?.Invoke(10);
            }
        }).AddTo(_disposable);
    }

    public Action<float> ValueChanged { get; set; }

    public void Dispose()
    {
        _disposable.Clear();
    }
}
