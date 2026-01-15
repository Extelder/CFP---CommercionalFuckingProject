using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class UnitFactory : AbstractFactory<UnitProduct>
{
    [field: SerializeField] public override UnitProduct SpawnProduct { get; set; }
    private readonly DiContainer _container;
    private readonly GameObject _prefab;
    private readonly Transform _spawnPoint;
    
    public UnitFactory(DiContainer container, GameObject prefab, Transform spawnPoint)
    {
        _container = container;
        _prefab = prefab;
        _spawnPoint = spawnPoint;
    }
    
    public override UnitProduct CreateProduct()
    {
        return _container.InstantiatePrefabForComponent<UnitProduct>(_prefab, _spawnPoint);
    }
}
