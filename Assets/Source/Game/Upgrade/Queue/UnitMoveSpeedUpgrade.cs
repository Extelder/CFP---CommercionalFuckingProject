using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UnitMoveSpeedUpgrade : UpgradeByTiers<float>
{
    [Inject] private IUnitMoveSpeedUpgradable _unitMoveSpeedUpgradable;
    
    public override void Upgrade() 
    {
        _unitMoveSpeedUpgradable.Upgrade(currentUpgradeTier.Value);
    }
}
