using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class QueuePurchasableHandler<T> : QueueMovableHandler<T>, IInitializable, IDisposable  where T : CustomerUnitProduct
{
    public QueuePurchasableHandler(Queue<T> queue, IQueueContainable queueContainable, AbstractFactory<T> factory,
        QueueConfig config) : base(queue, queueContainable, factory, config)
    {
    }

    public void Initialize()
    {
        queueContainable.RunCoroutine(FillQueueOnStart());
        queueContainable.UnitSpawnPoint.localPosition = new Vector3(-queueContainable.Offset * config.MaxQueueCapacity, 0, 0);
    }

    public override void SetFirstUnitInQueue()
    {
        base.SetFirstUnitInQueue();
        currentFirstUnitInQueue.Bought += OnUnitBought;
    }

    private void OnUnitBought()
    {
        queueContainable.RunCoroutine(AddToQueueSeparetly());
    }
    
    public void Dispose()
    {
        if (currentFirstUnitInQueue == null)
            return;
        currentFirstUnitInQueue.Bought -= OnUnitBought;
    }
}