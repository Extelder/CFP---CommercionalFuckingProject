using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerResourceTransferTrigger : MonoBehaviour, IResourceContainerTransfer
{
    [field: SerializeField] public ResourceContainer ResourceContainer { get; set; }

    private ResourceTransfer _resourceTransfer;
    private ResourceContainerView _containerView;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player Player))
        {
            _resourceTransfer = new ResourceTransfer(Player.ResourceContainer, ResourceContainer, 1f, _disposable);

            _containerView =
                new ResourceContainerView(ResourceContainer, ResourceContainer.SpawnPoint);
        }
    }

    private void OnDisable()
    {
        _disposable?.Clear();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player Player))
        {
            _disposable.Clear();
            _resourceTransfer = null;
            _containerView = null;
        }
    }
}