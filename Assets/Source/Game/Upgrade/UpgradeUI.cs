using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private TextMeshProUGUI _upgradeNameText;

    private Upgrade _upgrade;
    private UpgradeShop _upgradeShop;

    public void Init(Upgrade upgrade, UpgradeShop upgradeShop)
    {
        _upgrade = upgrade;
        _upgradeShop = upgradeShop;
        _upgrade.Upgraded += OnUpgraded;
        UpdateCurrentData();
    }

    private void OnUpgraded()
    {
        UpdateCurrentData();
    }

    public void UpdateCurrentData()
    {
        _costText.text = _upgrade.GetCurrentCost().ToString();
        _valueText.text = _upgrade.GetCurrentValueByString();
        _upgradeNameText.text = _upgrade.Name;
    }

    public void TryUpgrade()
    {
        _upgradeShop.BuyUpgrade(_upgrade);
    }

    private void OnDisable()
    {
        _upgrade.Upgraded -= OnUpgraded;
    }
}