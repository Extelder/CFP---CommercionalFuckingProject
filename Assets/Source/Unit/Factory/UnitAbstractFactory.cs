using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitAbstractFactory : AbstractFactory<UnitProduct>
{
    [field: SerializeField] public override UnitProduct SpawnProduct { get; set; }
    [SerializeField] protected Transform origin;


    public override UnitProduct CreateProduct()
    {
        UnitProduct abstactProduct = Instantiate(SpawnProduct, origin);
        abstactProduct.Init();
        return abstactProduct;
    }
}
