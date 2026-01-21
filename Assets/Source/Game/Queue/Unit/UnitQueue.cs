using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class UnitQueue : Queue<CustomerUnitProduct>
{
    public override List<CustomerUnitProduct> UnitsInQueue { get; set; } = new List<CustomerUnitProduct>();

    public override void AddToQueue(CustomerUnitProduct product)
    {
        UnitsInQueue.Add(product);
    }

    public override void SubstractToQueue(CustomerUnitProduct product)
    {
        if (UnitsInQueue.Count > 0)
        {
            UnitsInQueue.Remove(product);
        }
    }
}