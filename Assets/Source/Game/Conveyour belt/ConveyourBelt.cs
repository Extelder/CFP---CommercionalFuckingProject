using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyourBelt : MonoBehaviour
{
    [SerializeField] private GameObject[] _resourceVisuals;
    
    [SerializeField] private IResourceContainerTransfer _resourceContainerTransfer;

    private void OnEnable()
    {
        _resourceContainerTransfer.ResourceContainer.ValueChanged += OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        for (int i = 0; i < _resourceContainerTransfer.ResourceContainer.MaxValue; i++)
        {
            if (value -1 >= i)
            {
                _resourceVisuals[i].SetActive(true);
                continue;
            }

            _resourceVisuals[i].SetActive(false);
        }
    }

    private void OnDisable()
    {
        _resourceContainerTransfer.ResourceContainer.ValueChanged -= OnValueChanged;
    }
}