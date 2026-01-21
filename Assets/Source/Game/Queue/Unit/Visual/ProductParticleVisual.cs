using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductParticleVisual : MonoBehaviour, IParticlePlayable
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AbstractProduct _product;
    private void OnEnable()
    {
        _product.Initialized += OnInitialized;
    }

    private void OnInitialized()
    {
        ParticleHandler handler = new ParticleHandler(this, this);
    }

    public void PlayUnitParticle()
    {
        _particleSystem.Play();
    }

    private void OnDisable()
    {
        _product.Initialized -= OnInitialized;
    }

    public event Action ParticlePlay;
}
