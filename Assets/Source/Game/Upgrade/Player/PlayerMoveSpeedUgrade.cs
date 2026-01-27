using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMoveSpeedUgrade : UpgradeByTiers<float>
{
    [Inject] private IPlayerMoveSpeedUpgradable _playerMoveSpeedUpgradable;

    public override void Upgrade()
    {
        _playerMoveSpeedUpgradable.Upgrade(currentUpgradeTier.Value);
    }
}