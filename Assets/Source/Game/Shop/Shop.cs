using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shop
{
    private UnitProduct _currentFirstUnitInQueue;
    
    public void SetFirstUnitInQueue(UnitProduct unitProduct)
    {
        Debug.Log("shopSet");
        _currentFirstUnitInQueue = unitProduct;
    }

    public bool TryBuy(int recourcesCount)
    {
        if (recourcesCount >= _currentFirstUnitInQueue.NeededResources)
        {
            Debug.Log("shopBuy");
            _currentFirstUnitInQueue.Buy();
            return true;
        }

        return false;
    }
}
