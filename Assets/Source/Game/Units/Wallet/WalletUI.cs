using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletUI : IDisposable
{
    protected Wallet wallet;
    protected TextMeshProUGUI moneyText;

    public WalletUI(Wallet wallet, TextMeshProUGUI text)
    {
        moneyText = text;

        this.wallet = wallet;
        this.wallet.ValueChanged += OnValueChanged;
        OnValueChanged(wallet.Value);
    }

    private void OnValueChanged(int value)
    {
        moneyText.text = value.ToString();
    }

    public void Dispose()
    {
        wallet.ValueChanged -= OnValueChanged;
    }
}