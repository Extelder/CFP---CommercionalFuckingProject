using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class Shop
{
    public IUnitPurchasable UnitPurchasable { get; private set; }

    public IUnitPurchasable SetCurrentUnitPurchasable(IUnitPurchasable unitPurchasable) => (UnitPurchasable = unitPurchasable);
    public IUnitPurchasable GetCurrentUnitPurchasable() => (UnitPurchasable);
}