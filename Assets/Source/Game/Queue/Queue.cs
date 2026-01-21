using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class Queue<T> where T : AbstractProduct
{
    public abstract List<T> UnitsInQueue { get; set; }
    public int Count => (UnitsInQueue.Count);
    
    public abstract void AddToQueue(T product);

    public abstract void SubstractToQueue(T product);
}