using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitCutDownTrigger : MonoBehaviour, IPlayerUnitCutDownInput
{
    public event Action StartAction;
    public event Action StopAction;
    [field: SerializeField] public GameObject Tree { get; set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IUnitActionProvider>(out IUnitActionProvider provider))
        {
            provider.Provide(this);
            StartAction?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<IUnitActionProvider>(out IUnitActionProvider provider))
        {
            StopAction?.Invoke();
        }
    }
}