using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ConveyorSpeedUpgrade : UpgradeByTiers<float>
{
    [Inject] private IConveyorSpeedUpgradable _conveyorSpeedUpgradable;
    
    public override void Upgrade() 
    {
        _conveyorSpeedUpgradable.Upgrade(currentUpgradeTier.Value);
    }
}
