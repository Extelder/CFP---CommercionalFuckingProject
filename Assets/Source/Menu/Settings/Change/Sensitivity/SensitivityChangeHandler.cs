using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensitivityChangeHandler : SettingsChangeHandler<float>
{
    private SettingsChange<float> _settingsChange;
    
    public SensitivityChangeHandler(ISettingsChangerInput<float> settingsChangerInput, SettingsChange<float> settingsChange) : base(settingsChangerInput)
    {
        _settingsChange = settingsChange;
    }
    
    public override void OnValueChanged(float value)
    {
        _settingsChange.Perform(value);
    }
}
