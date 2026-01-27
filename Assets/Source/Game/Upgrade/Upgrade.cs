using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


[Serializable]
public struct UpgradeTier<T>
{
    [field: SerializeField] public uint Cost { get; private set; }
    [field: SerializeField] public T Value { get; private set; }
}

[Serializable]
public abstract class Upgrade
{
    [field: SerializeField] public string Name { get; private set; }
    public abstract event Action Upgraded;
    public abstract event Action MaxLevelReached;

    public int CurrentTierId { get; protected set; }

    public abstract void Bootstrap();
    public abstract void Perform();
    public abstract uint GetCurrentCost();
    public abstract string GetCurrentValueByString();
    public abstract bool CanBeUpgraded();

    public void Inject(DiContainer container)
    {
        container.Inject(this);
    }
}