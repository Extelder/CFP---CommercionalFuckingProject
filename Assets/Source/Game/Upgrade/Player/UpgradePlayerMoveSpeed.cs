using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

[Serializable]
public class UpgradePlayerMoveSpeed : Upgrade
{
    [field: SerializeField] public UpgradeTier<float>[] UpgradeTiers { get; protected set; }

    [Inject] private IPlayerMoveSpeedUpgradable _playerMoveSpeedUpgradable;

    private UpgradeTier<float> _currentUpgradeTier;

    public override event Action Upgraded;


    public UpgradePlayerMoveSpeed()
    {
    }

    public override void Bootstrap()
    {
        CurrentTierId = 0;
        _currentUpgradeTier = UpgradeTiers[CurrentTierId];
    }

    public override uint GetCurrentCost() => _currentUpgradeTier.Cost;

    public override string GetCurrentValueByString() => _currentUpgradeTier.Value.ToString();
    public override bool CanBeUpgraded() => CurrentTierId < UpgradeTiers.Length - 1;

    public override void Perform()
    {
        _playerMoveSpeedUpgradable.Upgrade(_currentUpgradeTier.Value);
        CurrentTierId++;
        _currentUpgradeTier = UpgradeTiers[CurrentTierId];
        Upgraded?.Invoke();
    }
}