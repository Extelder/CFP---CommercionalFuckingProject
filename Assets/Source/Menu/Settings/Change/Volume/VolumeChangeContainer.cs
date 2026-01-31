using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

[Serializable]
public class VolumeChangeContainer : SettingsChangeContainer
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public AudioMixer Mixer { get; private set; }
    [Inject] private ISettingsViewable viewable;

    private VolumeChangeUIContainer _volumeChangeUIContainer;
    private VolumeChanger _volumeChanger;
    private VolumeChangeHandler _volumeChangeHandler;
    
    public override void Initialize()
    {
        Debug.Log(viewable);
        _volumeChangeUIContainer = new VolumeChangeUIContainer(viewable, container, Name);
        _volumeChanger = new VolumeChanger(Mixer, Name);
        _volumeChangeHandler = new VolumeChangeHandler(_volumeChangeUIContainer, _volumeChanger);
    }

    public override void Dispose()
    {
        base.Dispose();
        _volumeChangeUIContainer.Dispose();
        _volumeChangeHandler.Dispose();
    }
}
