using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class QueueHandler<T> where T : AbstractProduct
{
    protected T currentFirstUnitInQueue;
    protected Queue<T> queue;
    protected AbstractFactory<T> factory;
    protected IQueueContainable queueContainable;

    protected QueueConfig config;

    public QueueHandler(Queue<T> queue, IQueueContainable queueContainable, AbstractFactory<T> factory, QueueConfig config)
    {
        this.queue = queue;
        this.factory = factory; 
        this.queueContainable = queueContainable;
        this.config = config;
    }

    public IEnumerator FillQueueOnStart()
    {
        int currentUnitCount = 0;
        while (true)
        {
            yield return new WaitForSeconds(config.SpawnCooldown);
            AddToQueue(queueContainable.QueueSpawnPoint.position + new Vector3(-queueContainable.Offset * currentUnitCount, 0, 0));
            if (currentUnitCount > config.MaxQueueCapacity - 1)
            {
                Debug.Log("SETFIRST");
                SetFirstUnitInQueue();
                break;
            }

            currentUnitCount++;
        }
    }

    public IEnumerator AddToQueueSeparetly()
    {
        AddBeforeRemove();
        queue.SubstractToQueue(currentFirstUnitInQueue);
        SetFirstUnitInQueue();
        AddAfterRemove();
        yield return new WaitForSeconds(config.SpawnCooldown);
        AddToQueue(queueContainable.UnitSpawnPoint.position);
    }

    private void AddToQueue(Vector3 position)
    {
        if (queue.UnitsInQueue.Count < config.MaxQueueCapacity)
            queue.AddToQueue(factory.CreateProduct(position));
    }
    public abstract void AddBeforeRemove();

    public abstract void AddAfterRemove();

    public virtual void SetFirstUnitInQueue()
    {
        currentFirstUnitInQueue = queue.UnitsInQueue[0];
    }
}
