using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerCutDownSpeedUpgrade : UpgradeByTiers<float>
{
    [Inject] private IPlayerCutDownSpeedUpgradable _playerCutDownSpeedUpgradable;

    public override void Upgrade() 
    {
        _playerCutDownSpeedUpgradable.Upgrade(currentUpgradeTier.Value);
    }
}
