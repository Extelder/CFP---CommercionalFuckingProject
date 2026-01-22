using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopContainer : MonoBehaviour, IResourceContainerTransfer
{
    [field: SerializeField] public ResourceContainer ResourceContainer { get; set; }

    private void Start()
    {
        ResourceContainerView resourceContainerView =
            new ResourceContainerView(ResourceContainer, ResourceContainer.SpawnPoint);
    }
}