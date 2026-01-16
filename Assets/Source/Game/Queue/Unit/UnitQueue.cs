using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public abstract class UnitQueue : Queue
{
    [SerializeField] private Transform _defaultSpawnPoint;
    [SerializeField] private float _offset;
    [SerializeField] private Transform _targetPointToMove;
    protected float spawnCooldown;
    protected int maxQueueCapacity;
    private UnitFactory _factory;
    private int _currentUnitCount;
    private List<UnitProduct> _unitsInQueue = new List<UnitProduct>();
    private UnitProduct _currentFirstUnitProductInQueue;

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
            _unitsInQueue.Remove(_currentFirstUnitProductInQueue);
            SetFirstUnitAndMove();
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
                SetFirstUnitAndMove();
                break;
            }
            _currentUnitCount++;
        }
    }

    private void SetFirstUnitAndMove()
    {
        Debug.Log("SET FIRST");
        _currentFirstUnitProductInQueue = _unitsInQueue[maxQueueCapacity - 1];
        _currentFirstUnitProductInQueue.Move(_targetPointToMove);
    }
}
