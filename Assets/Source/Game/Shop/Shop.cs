using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class Shop : IDisposable
{
    private CompositeDisposable _timeDisposable = new CompositeDisposable();
    private CompositeDisposable _buyDisposable = new CompositeDisposable();

    private IUnitPurchasable _unitPurchasable;
    private ShopContainer _shopContainer;
    private ShopConfig _config;

    public Shop(ShopContainer shopContainer, ShopConfig config)
    {
        _shopContainer = shopContainer;
        _config = config;
    }

    public void SetFirstUnitInQueue(IUnitPurchasable unitPurchasable)
    {
        _unitPurchasable = unitPurchasable;
        CheckOnCooldown();
    }

    private void CheckOnCooldown()
    {
        _timeDisposable.Clear();
        float currentTime = 0;
        Observable.Interval(TimeSpan.FromSeconds(0.1f)).Subscribe(_ =>
        {
            currentTime += 0.1f;
            if (currentTime >= _config.BuyCooldown)
            {
                CheckOnBuy();
                _timeDisposable.Clear();
            }
        }).AddTo(_timeDisposable);
    }

    private void CheckOnBuy()
    {
        _buyDisposable.Clear();
        Observable.Interval(TimeSpan.FromSeconds(0.2f)).Subscribe(_ => { _unitPurchasable.Buy(); })
            .AddTo(_buyDisposable);
    }


    public bool TryRemove()
    {
        return _shopContainer.ResourceContainer.TryRemove(_unitPurchasable.NeededRecources);
    }

    public void Dispose()
    {
        _timeDisposable.Clear();
        _buyDisposable.Clear();
    }
}