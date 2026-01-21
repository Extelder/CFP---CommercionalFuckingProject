using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueView : MonoBehaviour, IQueueContainable
{
    [field: SerializeField] public Transform TargetPoint { get; set; }
    [field: SerializeField] public Transform QueueSpawnPoint { get; set; }
    [field: SerializeField] public Transform UnitSpawnPoint { get; set; }
    [field: SerializeField] public float Offset { get; set; }
    private Coroutine _coroutine;
    
    public void RunCoroutine(IEnumerator coroutine)
    {
        _coroutine = StartCoroutine(coroutine);
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }
}
