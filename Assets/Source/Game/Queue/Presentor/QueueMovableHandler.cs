using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueMovableHandler<T> : QueueHandler<T> where T : UnitProduct
{
    public QueueMovableHandler(Queue<T> queue, IQueueContainable queueContainable, AbstractFactory<T> factory,
        QueueConfig config) : base(queue, queueContainable, factory, config)
    {
    }

    private void Move()
    {
        for (int i = 0; i < queue.Count; i++)
        {
            queue.UnitsInQueue[i]
                .Move(queue.UnitsInQueue[i].Transform.position + new Vector3(queueContainable.Offset, 0, 0));
        }
    }

    public override void AddBeforeRemove()
    {
        currentFirstUnitInQueue.Move(queueContainable.TargetPoint.position);
    }

    public override void AddAfterRemove()
    {
        Move();
    }
}