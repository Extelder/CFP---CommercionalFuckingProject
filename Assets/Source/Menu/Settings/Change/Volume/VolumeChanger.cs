using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

public class VolumeChanger : SettingsChange<float>
{
    private AudioMixer _mixer;
    private string _name;
    
    public VolumeChanger(AudioMixer mixer, string name)
    {
        _mixer = mixer;
        _name = name;
    }

    public override void Perform(float value)
    {
        _mixer.SetFloat(_name, value);
    }
}
