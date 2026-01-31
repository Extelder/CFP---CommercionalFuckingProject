using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class SettingsChangeUIContainer<T> : ISettingsChangerInput<T>
{
    protected DiContainer container;
    protected ISettingsViewable viewable;
    protected Transform parentOrigin;

    public SettingsChangeUIContainer(ISettingsViewable viewable, DiContainer container)
    {
        this.viewable = viewable;
        parentOrigin = viewable.ParentOrigin;
        this.container = container;
    }

    public abstract Action<T> ValueChanged { get; set; }
}
