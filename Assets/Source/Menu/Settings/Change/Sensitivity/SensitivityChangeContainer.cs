using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[Serializable]
public class SensitivityChangeContainer : SettingsChangeContainer
{
    [Inject] private ISettingsViewable viewable;
    
    public override void Initialize()
    {
        Debug.Log(viewable);
        SensititvityChangeUIContainer sensititvityChangeUIContainer = new SensititvityChangeUIContainer(viewable, container);
        SensitivityChanger sensitivityChanger = new SensitivityChanger();
        SensitivityChangeHandler sensitivityChangeHandler = new SensitivityChangeHandler(sensititvityChangeUIContainer, sensitivityChanger);
    }
}
