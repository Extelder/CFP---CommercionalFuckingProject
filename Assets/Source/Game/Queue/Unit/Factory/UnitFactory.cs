using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class UnitFactory : AbstractFactory<UnitProduct>
{
    [field: SerializeField] public override UnitProduct SpawnProduct { get; set; }
    protected DiContainer container;
    protected GameObject prefab;

    public UnitFactory(DiContainer container, GameObject prefab)
    {
        this.container = container;
        this.prefab = prefab;
    }

    public override UnitProduct CreateProduct(Vector3 spawnPosition)
    {
        return container.InstantiatePrefabForComponent<UnitProduct>(prefab,
            spawnPosition, Quaternion.identity, null);
    }
}