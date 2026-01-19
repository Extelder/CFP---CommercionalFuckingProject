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
    [SerializeField] private UnitProduct _currentFirstUnitInQueue;
    [SerializeField] private List<UnitProduct> _unitsInQueue = new List<UnitProduct>();

    [Inject]
    public void Construct(QueueConfig config, UnitFactory factory)
    {
        maxQueueCapacity = config.MaxQueueCapacity;
        spawnCooldown = config.SpawnCooldown;
        _factory = factory;
    }

    private void OnUnitBought()
    {
        SubstractToQueue();
    }

    private void Start()
    {
        StartCoroutine(FillQueueOnStart());
        _defaultSpawnPoint.localPosition = new Vector3(-_offset * maxQueueCapacity, 0, 0);
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
            _currentFirstUnitInQueue.Move(_targetPoint.position);
            _unitsInQueue.Remove(_currentFirstUnitInQueue);
            StartCoroutine(AddToQueueSeparately());
        }
    }

    private IEnumerator AddToQueueSeparately()
    {
        _currentFirstUnitInQueue = _unitsInQueue[0];
        MoveUnitsInQueue();
        _currentFirstUnitInQueue.Bought += OnUnitBought;
        yield return new WaitForSeconds(spawnCooldown);
        AddToQueue(_defaultSpawnPoint.position);
    }

    private IEnumerator FillQueueOnStart()
    {
        int currentUnitCount = 0;
        while (true)
        {
            yield return new WaitForSeconds(spawnCooldown);
            AddToQueue(transform.position + new Vector3(-_offset * currentUnitCount, 0, 0));
            if (currentUnitCount > maxQueueCapacity - 1)
            {
                _currentFirstUnitInQueue = _unitsInQueue[0];
                _currentFirstUnitInQueue.Bought += OnUnitBought;
                break;
            }

            currentUnitCount++;
        }
    }

    private void MoveUnitsInQueue()
    {
        for (int i = 0; i < _unitsInQueue.Count; i++)
        {
            _unitsInQueue[i].Move(_offset);
        }
    }

    private void OnDisable()
    {
        _currentFirstUnitInQueue.Bought -= OnUnitBought;
    }
}