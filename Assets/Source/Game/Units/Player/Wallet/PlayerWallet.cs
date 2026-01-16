using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallet : Wallet
{
    public PlayerWallet(int minValue, uint maxValue, int startValue) : base(minValue, maxValue, startValue)
    {
    }
}