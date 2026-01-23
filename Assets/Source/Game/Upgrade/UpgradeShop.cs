using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShop : MonoBehaviour
{
    [SerializeField] [SerializeReference] [SerializeReferenceButton]
    private Upgrade[] _upgrades;

    public void BuyUpgrade(Upgrade upgrade)
    {
        upgrade.Perform();
    }

    public void BuyUpgrade(int id)
    {
        BuyUpgrade(_upgrades[id]);
    }
}