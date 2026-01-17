using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class UnitQueue : Queue
{
    [SerializeField] private Transform _defaultSpawnPoint;
    [SerializeField] private float _offset;
    [SerializeField] private Transform _targetPoint;
    protected float spawnCooldown;
    protected int maxQueueCapacity;
    private UnitFactory _factory;
    private int _currentUnitCount;
    private List<UnitProduct> _unitsInQueue = new List<UnitProduct>();

    [Inject]
    public void Construct(QueueConfig config, UnitFactory factory)
    {
        maxQueueCapacity = config.MaxQueueCapacity;
        spawnCooldown = config.SpawnCooldown;
        _factory = factory;
    }

    private void Start()
    {
        StartCoroutine(WaitToSpawnNewUnit());
    }

    public override void AddToQueue(Vector3 position)
    {
        if (_unitsInQueue.Count < maxQueueCapacity)
        {
            _unitsInQueue.Add(_factory.CreateProduct(position));
        }
    }

    public override void SubstractToQueue()
    {
        if (_unitsInQueue.Count > 0)
        {
            UnitProduct currentFirstUnitInQueue = _unitsInQueue[maxQueueCapacity - 1];
            currentFirstUnitInQueue.Move(_targetPoint.position);
            _unitsInQueue.Remove(currentFirstUnitInQueue);
            StartCoroutine(WaitToSpawnNewUnit());
        }
    }

    private IEnumerator WaitToSpawnNewUnit()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnCooldown);

            AddToQueue(_defaultSpawnPoint.position + new Vector3(_offset * _currentUnitCount, 0, 0));
            if (_currentUnitCount > maxQueueCapacity)
            {
                MoveUnitsInQueue();
                _currentUnitCount = 0;
                break;
            }

            _currentUnitCount++;
        }
    }

    private void MoveUnitsInQueue()
    {
        for (int i = 0; i < _unitsInQueue.Count; i++)
        {
            _unitsInQueue[i].Move(_offset);
        }
    }
}