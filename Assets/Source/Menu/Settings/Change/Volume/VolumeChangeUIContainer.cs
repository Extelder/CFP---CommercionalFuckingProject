using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class VolumeChangeUIContainer : SettingsChangeUIContainer<float>, IDisposable
{
    private SliderUIChangeInput _sliderUIChangeInput;
    
    public VolumeChangeUIContainer(ISettingsViewable viewable, DiContainer container, string name) : base(viewable, container)
    {
        _sliderUIChangeInput = this.container.InstantiatePrefabForComponent<SliderUIChangeInput>(
            this.viewable.SettingsDefaultUIConfig.DefaultSliderPrefab, parentOrigin);
        _sliderUIChangeInput.ChangeName(name);
        _sliderUIChangeInput.InputProvider.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(float value)
    {
        ValueChanged?.Invoke(value);
    }

    public override Action<float> ValueChanged { get; set; }

    public void Dispose()
    {
        _sliderUIChangeInput.InputProvider.onValueChanged.RemoveListener(OnValueChanged);
    }
}
