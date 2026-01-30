using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[Serializable]
public abstract class SettingsChange<T>
{
    [field: SerializeField] public string Name { get; private set; }
    public abstract void Perform(T value);
    
    public void Inject(DiContainer container)
    {
        container.Inject(this);
    }
}
