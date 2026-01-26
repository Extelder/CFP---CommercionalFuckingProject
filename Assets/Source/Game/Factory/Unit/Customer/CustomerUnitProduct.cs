using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class CustomerUnitProduct : UnitProduct, IUnitPurchasable
{
    [SerializeField] private Animator _animator;
    public event Action Bought;
    public uint NeededRecources { get; set; }
    private Shop _shop;
    private CustomerAnimator _customerAnimator;
    
    private CompositeDisposable _disposable = new CompositeDisposable();

    [Inject]
    public void Construct(UnitConfig config, Shop shop)
    {
        NeededRecources = config.NeededRecources;
        _shop = shop;
    }

    public override void Init()
    {
        base.Init();
        _customerAnimator = new CustomerAnimator(_animator, this, _disposable);
    }

    public void Buy()
    {
        if (_shop.TryRemove())
        {
            Bought?.Invoke();
        }
    }

    private void OnDisable()
    {
        _disposable.Clear();
        _customerAnimator?.Dispose();
    }
}
