using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ResourceContainerView : IDisposable
{
    private ResourceContainer _resourceContainer;

    private List<GameObject> SpawnedResources = new List<GameObject>();

    public ResourceContainerView(ResourceContainer resourceContainer, Transform resourceSpawnPoint)
    {
        _resourceContainer = resourceContainer;
        _resourceContainer.ValueChanged += OnValueChanged;
        for (int i = 0; i < _resourceContainer.MaxValue; i++)
        {
            SpawnedResources.Add(MonoBehaviour.Instantiate(_resourceContainer.ResourcesType.Prefab,
                resourceSpawnPoint.position + new Vector3(0, i * 0.1f, 0), Quaternion.identity, resourceSpawnPoint));
            SpawnedResources[i].SetActive(false);
        }
    }

    private void OnValueChanged(int value)
    {
     
        for (int i = 0; i < _resourceContainer.MaxValue; i++)
        {
            if (value -1 >= i)
            {
                SpawnedResources[i].SetActive(true);
                continue;
            }

            SpawnedResources[i].SetActive(false);
        }
    }

    public void Dispose()
    {
        _resourceContainer.ValueChanged -= OnValueChanged;
    }
}