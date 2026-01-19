using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SHOPCHECKDELETE : MonoBehaviour
{
    private Shop _shop;
    
    [Inject]
    public void Construct(Shop shop)
    {
        _shop = shop;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            _shop.TryBuy(100);
        }
    }
}
