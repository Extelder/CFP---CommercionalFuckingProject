using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopFirstCustomerChangerTrigger : MonoBehaviour
{
    private Shop _shop;
    
    [Inject]
    public void Construct(Shop shop)
    {
        _shop = shop;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IUnitPurchasable>(out IUnitPurchasable product))
        {
            _shop.SetFirstUnitInQueue(product);
        }
    }
}
