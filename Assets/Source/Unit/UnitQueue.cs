using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public abstract class UnitQueue : Queue
{
    [SerializeField] private float _spawnCooldown;
    protected int maxQueueCapacity;
    private UnitAbstractFactory _abstractFactory;
    private List<UnitProduct> _unitsInQueue = new List<UnitProduct>();
    private UnitProduct _currentFirstUnitProductInQueue;

    [Inject]
    public void Construct(QueueConfig config, UnitAbstractFactory abstractFactory)
    {
        maxQueueCapacity = config.MaxQueueCapacity;
        _abstractFactory = abstractFactory;
        for (int i = 0; i < maxQueueCapacity - 1; i++)
        {
            _unitsInQueue.Add(abstractFactory.CreateProduct());
        }
        _currentFirstUnitProductInQueue = _unitsInQueue[0];
    }

    public override void AddToQueue()
    {
        if (_unitsInQueue.Count < maxQueueCapacity - 1)
        {
            _unitsInQueue.Add(_abstractFactory.CreateProduct());
        }
    }

    public override void SubstractToQueue()
    {
        if (_unitsInQueue.Count > 0)
        {
            _unitsInQueue.Remove(_currentFirstUnitProductInQueue);
            StartCoroutine(WaitToSpawnNewUnit());
        }
    }

    private IEnumerator WaitToSpawnNewUnit()
    {
        yield return new WaitForSeconds(_spawnCooldown);
        AddToQueue();
    }
}
