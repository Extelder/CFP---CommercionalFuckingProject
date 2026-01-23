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
    private bool _canBuy;

    public Shop(ShopContainer shopContainer, ShopConfig config)
    {
        _shopContainer = shopContainer;
        _shopContainer.ResourceContainer.Added += OnValueAdded;
        _config = config;
    }

    public void SetFirstUnitInQueue(IUnitPurchasable unitPurchasable)
    {
        _unitPurchasable = unitPurchasable;
        CheckOnCooldown();
    }

    private void OnValueAdded(int value)
    {
        Observable.Interval(TimeSpan.FromSeconds(0.02f)).Subscribe(_ =>
        {
            if (_canBuy)
            {
                _unitPurchasable.Buy();
                _canBuy = false;
                _buyDisposable.Clear();
            }
        }).AddTo(_buyDisposable);
    }

    private void CheckOnCooldown()
    {
        float currentTime = 0;
        Observable.Interval(TimeSpan.FromSeconds(0.1f)).Subscribe(_ =>
        {
            currentTime += 0.1f;   
            if (currentTime >= _config.BuyCooldown)
            {
                _canBuy = true;
                _timeDisposable.Clear();
            }
        }).AddTo(_timeDisposable);
    }
    

    public bool TryRemove()
    {
        return _shopContainer.ResourceContainer.TryRemove(_unitPurchasable.NeededRecources);
    }

    public void Dispose()
    {
        _shopContainer.ResourceContainer.Added -= OnValueAdded;
        _timeDisposable.Clear();
        _buyDisposable.Clear();
    }
}