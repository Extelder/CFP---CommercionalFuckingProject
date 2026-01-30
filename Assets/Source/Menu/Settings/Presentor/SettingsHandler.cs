using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsHandler : IDisposable
{
    private ISettingsViewable _settingsViewable;
    private IKeyInput _keyInput;
    
    public SettingsHandler(ISettingsViewable viewable, IKeyInput keyInput)
    {
        _settingsViewable = viewable;
        _keyInput = keyInput;
        _keyInput.KeyPressed += OnKeyPressed;
        Debug.Log("SUBSCRIBEEE");
    }

    private void OnKeyPressed()
    {
        Debug.Log("KEY PRESSED");
        _settingsViewable.SettingsCanvas.enabled = !_settingsViewable.SettingsCanvas.enabled;
    }

    public void Dispose()
    {
        _keyInput.KeyPressed -= OnKeyPressed;
    }
}
