using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensitivityValueChanger : SettingsChanger<float>
{
    private SettingsChange<float> _settingsChange;
    
    public SensitivityValueChanger(ISettingsChangerInput<float> settingsChangerInput, SettingsChange<float> settingsChange) : base(settingsChangerInput)
    {
        _settingsChange = settingsChange;
    }

    public override void OnValueChanged(float value)
    {
        _settingsChange.Perform(value);
    }
}
