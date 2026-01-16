using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductParticleVisual : MonoBehaviour, IParticlePlayable
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AbstactProduct _product;
    private ParticleHandler _particleHandler;
    private void OnEnable()
    {
        _product.Initialized += OnInitialized;
    }

    private void OnInitialized()
    {
        ParticleHandler handler = new ParticleHandler(this, this);
        _particleHandler = handler;
    }

    public void PlayUnitParticle()
    {
        _particleSystem.Play();
    }

    private void OnDisable()
    {
        _product.Initialized -= OnInitialized;
        _particleHandler.Dispose();
    }

    public event Action ParticlePlay;
}
