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
        _unitPurchasable.Buy();
    }

    public bool TryBuy()
    {
        Debug.Log("TRY BUY");
            //RETURN TRYREMOVE
            return true;

        return false;
    }
}
