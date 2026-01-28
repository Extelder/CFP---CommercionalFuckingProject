using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ConveyourBeltResourceFactory : AbstractFactory<ConveyourResource>
{
    public override ConveyourResource SpawnProduct { get; set; }
    private DiContainer _container;

    public ConveyourBeltResourceFactory(ConveyourResource spawnProduct, DiContainer container)
    {
        SpawnProduct = spawnProduct;
        _container = container;
    }

    public override ConveyourResource CreateProduct(Vector3 spawnPoint)
    {
        return _container.InstantiatePrefabForComponent<ConveyourResource>(SpawnProduct, spawnPoint,
            Quaternion.identity, null);
    }
}