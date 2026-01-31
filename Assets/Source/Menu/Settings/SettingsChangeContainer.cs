using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[Serializable]
public abstract class SettingsChangeContainer : IDisposable
{
    protected DiContainer container;

    public abstract void Initialize();

    public virtual void Inject(DiContainer container)
    {
        this.container = container;
        container.Inject(this);
    }

    public virtual void Dispose()
    {
    }
}