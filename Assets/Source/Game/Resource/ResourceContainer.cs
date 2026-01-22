using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ResourceContainer
{
    [field: SerializeField] public Transform SpawnPoint { get; private set; }

    [field: SerializeField] public Resource ResourcesType { get; private set; }

    [field: SerializeField] public int CurrentValue { get; private set; }

    [field: SerializeField] public int MaxValue { get; private set; }
    private const int _minValue = 0;

    public event Action<int> ValueChanged;
    public event Action<int> Added;

    public ResourceContainer(Resource type, uint MaxValue, bool fillByDefault = false)
    {
        if (MaxValue <= _minValue)
        {
            Debug.LogError(this + " ResourceContainer maxValue <= minValue");
            Debug.Break();
            return;
        }

        this.MaxValue = (int) MaxValue;
        ResourcesType = type;
        if (fillByDefault)
        {
            CurrentValue = this.MaxValue;
            ValueChanged?.Invoke(CurrentValue);
        }
    }

    public bool TryAdd(uint value, Resource resources)
    {
        if (resources != ResourcesType)
        {
            return false;
        }

        if (CurrentValue + value > MaxValue)
            return false;

        CurrentValue += (int) value;
        ValueChanged?.Invoke(CurrentValue);
        Added?.Invoke((int)value);
        return true;
    }

    public bool TryRemove(uint value)
    {
        if (CurrentValue - value < _minValue)
            return false;

        CurrentValue -= (int) value;
        ValueChanged?.Invoke(CurrentValue);
        return true;
    }
}