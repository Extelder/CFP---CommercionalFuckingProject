using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ResourceTransfer
{
    public ResourceTransfer(ResourceContainer fromContainer, ResourceContainer toContainer, float transferRate,
        CompositeDisposable disposable)
    {
        Observable.Interval(TimeSpan.FromSeconds(transferRate)).Subscribe(_ =>
        {
            if (fromContainer.TryRemove(1))
            {
                toContainer.TryAdd(1, toContainer.ResourcesType);
                return;
            }

            disposable.Clear();
        }).AddTo(disposable);
    }
}