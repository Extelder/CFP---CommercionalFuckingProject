using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SensitivityChanger : SettingsChange<float>
{
    //[Inject] private ISensitivityChangable _sensitivityChangable;
    
    public override void Perform(float value)
    {
        //_sensitivityChangable.Change(value);
        Debug.Log("SENSITIVITY CHANGED" + value);
    }
}
