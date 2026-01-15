using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public abstract class UnitQueue : Queue
{
    [SerializeField] protected float spawnCooldown;
    protected int maxQueueCapacity;
    private UnitFactory _factory;
    private List<UnitProduct> _unitsInQueue = new List<UnitProduct>();
    private UnitProduct _currentFirstUnitProductInQueue;

    [Inject]
    public void Construct(QueueConfig config, UnitFactory factory)
    {
        maxQueueCapacity = config.MaxQueueCapacity;
        _factory = factory;
        for (int i = 0; i < maxQueueCapacity - 1; i++)
        {
            _unitsInQueue.Add(factory.CreateProduct());
        }
        _currentFirstUnitProductInQueue = _unitsInQueue[0];
    }

    public override void AddToQueue()
    {
        if (_unitsInQueue.Count < maxQueueCapacity - 1)
        {
            _unitsInQueue.Add(_factory.CreateProduct());
        }
    }

    public override void SubstractToQueue()
    {
        if (_unitsInQueue.Count > 0)
        {
            _unitsInQueue.Remove(_currentFirstUnitProductInQueue);
            _currentFirstUnitProductInQueue = _unitsInQueue[0];
            StartCoroutine(WaitToSpawnNewUnit());
        }
    }

    private IEnumerator WaitToSpawnNewUnit()
    {
        yield return new WaitForSeconds(spawnCooldown);
        AddToQueue();
    }
}
