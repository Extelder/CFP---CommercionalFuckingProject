using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class UnitFactory : AbstractFactory<CustomerUnitProduct>
{
    [field: SerializeField] public override CustomerUnitProduct SpawnProduct { get; set; }
    protected DiContainer container;
    protected GameObject prefab;

    public UnitFactory(DiContainer container, GameObject prefab)
    {
        this.container = container;
        this.prefab = prefab;
    }

    public override CustomerUnitProduct CreateProduct(Vector3 spawnPosition)
    {
        return container.InstantiatePrefabForComponent<CustomerUnitProduct>(prefab,
            spawnPosition, Quaternion.identity, null);
    }
}