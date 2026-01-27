using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

[Serializable]
public class UpgradeByTiers<T> : Upgrade
{
    [field: SerializeField] public UpgradeTier<T>[] UpgradeTiers { get; protected set; }

    protected UpgradeTier<T> currentUpgradeTier;

    public override event Action Upgraded;
    public override event Action MaxLevelReached;


    public UpgradeByTiers()
    {
    }

    public override void Bootstrap()
    {
        CurrentTierId = 0;
        currentUpgradeTier = UpgradeTiers[CurrentTierId];
    }

    public override uint GetCurrentCost() => currentUpgradeTier.Cost;

    public override string GetCurrentValueByString() => currentUpgradeTier.Value.ToString();
    public override bool CanBeUpgraded() => CurrentTierId < UpgradeTiers.Length;

    public virtual void Upgrade()
    {
    }

    public override void Perform()
    {
        Upgrade();
        CurrentTierId++;

        if (!(CurrentTierId > UpgradeTiers.Length - 1))
            currentUpgradeTier = UpgradeTiers[CurrentTierId];
        Upgraded?.Invoke();
        if (!CanBeUpgraded())
        {
            MaxLevelReached?.Invoke();
        }
    }
}