using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShopUI : MonoBehaviour
{
    [SerializeField] private UpgradeUI _upgradeUiPrefab;
    [SerializeField] private Transform _container;

    [SerializeField] private UpgradeShop _upgradeShop;

    private void Start()
    {
        for (int i = 0; i < _upgradeShop.Upgrades.Length; i++)
        {
            UpgradeUI upgradeUI = Instantiate(_upgradeUiPrefab, _container);
            upgradeUI.Init(_upgradeShop.Upgrades[i], _upgradeShop);
        }
    }
}