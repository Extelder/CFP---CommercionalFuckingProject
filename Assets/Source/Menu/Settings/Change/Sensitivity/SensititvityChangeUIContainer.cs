using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SensititvityChangeUIContainer : SettingsChangeUIContainer<float>
{
    public SensititvityChangeUIContainer(ISettingsViewable viewable, DiContainer container) : base(viewable, container)
    
    {
        Slider slider = this.container.InstantiatePrefabForComponent<Slider>(
            this.viewable.SettingsDefaultUIConfig.DefaultSliderPrefab, parentOrigin.position, Quaternion.identity,
            parentOrigin);
        slider.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(float value)
    {
        ValueChanged?.Invoke(value);
    }

    public override Action<float> ValueChanged { get; set; }
}