using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQueueContainable
{
    public Transform TargetPoint { get; set; }
    public Transform QueueSpawnPoint { get; set; }
    public Transform UnitSpawnPoint { get; set; }
    public float Offset { get; set; }

    public void RunCoroutine(IEnumerator coroutine);
}
