using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QueueConfig", menuName = "Queue")]
public class QueueConfig : ScriptableObject
{
    [field: SerializeField] public int MaxQueueCapacity { get; private set; }
    [field: SerializeField] public float SpawnCooldown { get; private set; }
}
