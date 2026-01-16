using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : IDisposable
{
    private IParticlePlayable _particlePlayable;
    private ProductParticleVisual _visual;
    
    public ParticleHandler(IParticlePlayable particlePlayable, ProductParticleVisual visual)
    {
        _visual = visual;
        _particlePlayable = particlePlayable;
        _particlePlayable.ParticlePlay += _visual.PlayUnitParticle;
    }
    
    public void Dispose()
    {
        _particlePlayable.ParticlePlay -= _visual.PlayUnitParticle;
    }
}
