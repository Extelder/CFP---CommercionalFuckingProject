using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PlayerResourceTransferTrigger : MonoBehaviour
{
    [SerializeField] private ResourceContainer _resourceContainer;

    private ResourceTransfer _resourceTransfer;
    private ResourceContainerView _containerView;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player Player))
        {
            _resourceTransfer = new ResourceTransfer(Player.ResourceContainer, _resourceContainer, 1f, _disposable);

            _containerView =
                new ResourceContainerView(_resourceContainer, _resourceContainer.SpawnPoint);
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