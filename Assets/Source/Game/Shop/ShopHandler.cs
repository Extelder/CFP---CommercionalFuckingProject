using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ShopHandler : IDisposable
{
    private Shop _shop;
    private PlayerWallet _wallet;
    private ShopContainer _shopContainer;
    private ShopConfig _config;

    private CompositeDisposable _timeDisposable = new CompositeDisposable();
    private CompositeDisposable _buyDisposable = new CompositeDisposable();

    public ShopHandler(ShopContainer shopContainer, ShopConfig config, Shop shop, PlayerWallet wallet)
    {
        _shopContainer = shopContainer;
        _config = config;
        _shop = shop;
        _wallet = wallet;
    }

    public void SetFirstUnitInQueue(IUnitPurchasable unitPurchasable)
    {
        _shop.SetCurrentUnitPurchasable(unitPurchasable);
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
        Observable.Interval(TimeSpan.FromSeconds(0.2f)).Subscribe(_ => { _shop.GetCurrentUnitPurchasable().Buy(); })
            .AddTo(_buyDisposable);
    }


    public bool TryRemove()
    {
        if (_shopContainer.ResourceContainer.TryRemove(_shop.GetCurrentUnitPurchasable().NeededRecources))
        {
            _wallet.Add(_config.RecoursePrice);
            return true;
        }
        return false;
    }

    public void Dispose()
    {
        _timeDisposable.Clear();
        _buyDisposable.Clear();
    }
}