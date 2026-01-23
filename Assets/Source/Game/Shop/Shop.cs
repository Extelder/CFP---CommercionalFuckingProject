using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shop : IDisposable
{
    private IUnitPurchasable _unitPurchasable;
    private ShopContainer _shopContainer;

    public Shop(ShopContainer shopContainer)
    {
        _shopContainer = shopContainer;
        _shopContainer.ResourceContainer.Added += OnValueAdded;
    }
    
    public void SetFirstUnitInQueue(IUnitPurchasable unitPurchasable)
    {
        _unitPurchasable = unitPurchasable;
    }

    private void OnValueAdded(int value)
    {
        _unitPurchasable.Buy();
    }

    public bool TryBuy()
    {
        return _shopContainer.ResourceContainer.TryRemove(_unitPurchasable.NeededRecources);
    }

    public void Dispose()
    {
        _shopContainer.ResourceContainer.Added -= OnValueAdded;
    }
}
