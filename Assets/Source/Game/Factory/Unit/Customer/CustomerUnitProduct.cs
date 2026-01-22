using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CustomerUnitProduct : UnitProduct, IUnitPurchasable
{
    public event Action Bought;
    public uint NeededRecources { get; set; }
    private Shop _shop;

    [Inject]
    public void Construct(UnitConfig config, Shop shop)
    {
        base.Construct(config);
        NeededRecources = config.NeededRecources;
        _shop = shop;
    }
    
    public void Buy()
    {
        if (_shop.TryBuy())
            Bought?.Invoke();
    }
}
