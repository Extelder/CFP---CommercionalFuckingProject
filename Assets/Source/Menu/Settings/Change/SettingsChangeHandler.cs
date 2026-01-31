using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SettingsChangeHandler<T> : IDisposable
{
    private ISettingsChangerInput<T> _settingsChangerInput;
    public SettingsChangeHandler(ISettingsChangerInput<T> settingsChangerInput)
    {
        _settingsChangerInput = settingsChangerInput;
        _settingsChangerInput.ValueChanged += OnValueChanged;
    }

    public abstract void OnValueChanged(T value);


    public void Dispose()
    {
        _settingsChangerInput.ValueChanged -= OnValueChanged;
    }
}
