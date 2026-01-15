using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class UnitFactory : AbstractFactory<UnitProduct>
{
    [field: SerializeField] public override UnitProduct SpawnProduct { get; set; }
    private DiContainer _container;
    private GameObject _prefab;

    public UnitFactory(DiContainer container, GameObject prefab)
    {
        _container = container;
        _prefab = prefab;
    }

    public override UnitProduct CreateProduct(Vector3 spawnPosition)
    {
        return _container.InstantiatePrefabForComponent<UnitProduct>(_prefab,
            spawnPosition, Quaternion.identity, null);
    }
}