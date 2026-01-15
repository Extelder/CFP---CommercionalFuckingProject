using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Queue : MonoBehaviour
{
    public abstract void AddToQueue(Vector3 position);

    public abstract void SubstractToQueue();
}