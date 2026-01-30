using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SettingsChangerInput : ISettingsChangerInput<float>, IDisposable
{
    private CompositeDisposable _disposable = new CompositeDisposable();
    
    public SettingsChangerInput()
    {
        CheckOnInput();
        SensitivityChanger sensitivityChanger = new SensitivityChanger();
        SensitivityValueChanger sensitivityValueChanger = new SensitivityValueChanger(this, sensitivityChanger);
    }

    private void CheckOnInput()
    {
        Observable.EveryUpdate().Subscribe(_ =>
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("CLICKED");
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
