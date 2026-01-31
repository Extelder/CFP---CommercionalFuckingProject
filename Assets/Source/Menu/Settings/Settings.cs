using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Settings : IDisposable
{
    private SettingsConfig _config;
    
    public Settings(SettingsConfig config, DiContainer container)
    {
        _config = config;
        for (int i = 0; i < _config.SettingsChangeContainers.Length; i++)
        {
            _config.SettingsChangeContainers[i].Inject(container);
            Debug.Log("INJECTED");
            _config.SettingsChangeContainers[i].Initialize();
            Debug.Log("INIT");
        }
    }

    public void Dispose()
    {
        for (int i = 0; i < _config.SettingsChangeContainers.Length; i++)
        {
            _config.SettingsChangeContainers[i].Dispose();
        }
    }
}
