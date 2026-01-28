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
    private ShopHandler _shopHandler;
    private CustomerAnimator _customerAnimator;
    
    private CompositeDisposable _disposable = new CompositeDisposable();

    [Inject]
    public void Construct(UnitConfig config, ShopHandler shopHandler)
    {
        NeededRecources = config.NeededRecources;
        _shopHandler = shopHandler;
    }

    public override void Init()
    {
        base.Init();
        _customerAnimator = new CustomerAnimator(_animator, this, _disposable);
    }

    public void Buy()
    {
        if (_shopHandler.TryRemove())
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
