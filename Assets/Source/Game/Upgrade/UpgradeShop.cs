using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UpgradeShop : MonoBehaviour
{
    [field: SerializeField]
    [field: SerializeReference]
    [field: SerializeReferenceButton]
    public Upgrade[] Upgrades { get; private set; }

    private PlayerWallet _wallet;

    [Inject]
    private void Construct(DiContainer container, PlayerWallet wallet)
    {
        _wallet = wallet;
        for (int i = 0; i < Upgrades.Length; i++)
        {
            Upgrades[i].Inject(container);
            Upgrades[i].Bootstrap();
        }
    }

    public void BuyUpgrade(Upgrade upgrade)
    {
        if (_wallet.TrySpend(upgrade.GetCurrentCost()))
        {
            upgrade.Perform();
        }
    }

    public void BuyUpgrade(int id)
    {
        BuyUpgrade(Upgrades[id]);
    }
}