using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shop
{
    private IUnitPurchasable _unitPurchasable;
    
    public void SetFirstUnitInQueue(IUnitPurchasable unitPurchasable)
    {
        Debug.Log("shopSet");
        _unitPurchasable = unitPurchasable;
    }

    public bool TryBuy(int recourcesCount)
    {
        Debug.Log("TRY BUY");
        if (recourcesCount >= _unitPurchasable.NeededRecources)
        {
            _unitPurchasable.Buy();
            return true;
        }

        return false;
    }
}
