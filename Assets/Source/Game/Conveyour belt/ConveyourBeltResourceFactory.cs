using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyourBeltResourceFactory : AbstractFactory<ConveyourResource>
{
    public override ConveyourResource SpawnProduct { get; set; }

    public ConveyourBeltResourceFactory(ConveyourResource spawnProduct)
    {
        SpawnProduct = spawnProduct;
    }

    public override ConveyourResource CreateProduct(Vector3 spawnPoint)
    {
        return MonoBehaviour.Instantiate(SpawnProduct, spawnPoint, Quaternion.identity);
    }
}