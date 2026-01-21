using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CustomerUnitProduct : UnitProduct, IUnitPurchasable
{
    public event Action Bought;
    public int NeededRecources { get; set; }

    [Inject]
    public void Construct(UnitConfig config)
    {
        base.Construct(config);
        NeededRecources = config.NeededRecources;
    }
    
    public void Buy()
    {
        Bought?.Invoke();
    }
}
