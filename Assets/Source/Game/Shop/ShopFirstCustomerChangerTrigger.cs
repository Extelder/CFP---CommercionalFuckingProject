using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopFirstCustomerChangerTrigger : MonoBehaviour
{
    private ShopHandler _shopHandler;
    
    [Inject]
    public void Construct(ShopHandler shop)
    {
        _shopHandler = shop;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IUnitPurchasable>(out IUnitPurchasable product))
        {
            _shopHandler.SetFirstUnitInQueue(product);
        }
        if (other.TryGetComponent<IUnitDeathable>(out IUnitDeathable deathable))
        {
            deathable.CanDie = true;
        }
    }
}
