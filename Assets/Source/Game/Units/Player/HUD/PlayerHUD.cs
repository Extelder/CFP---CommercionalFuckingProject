using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class PlayerHUD : MonoBehaviour
{
    [field: SerializeField] public TextMeshProUGUI MoneyText { get; private set; }
    [field: SerializeField] public Joystick Joystick { get; private set; }

    [Inject]
    public void Construct(PlayerWallet wallet)
    {
        WalletUI walletUi = new WalletUI(wallet, MoneyText);
    }
}