using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ConveyourResourceMoveHandler : IDisposable
{
    protected IConveyourResourceMoveInput input;
    protected ConveyourResource conveyourResource;

    public event Action PointReached;

    private Tween _tween;

    public ConveyourResourceMoveHandler(IConveyourResourceMoveInput conveyourResourceMoveInput,
        ConveyourResource resource)
    {
        input = conveyourResourceMoveInput;
        conveyourResource = resource;
        input.MoveInputReceived += OnMoveInputReceived;
    }

    public virtual void OnMoveInputReceived(Vector3 point)
    {
        Debug.Log("Move input received");
        
        _tween?.Kill();
        _tween = conveyourResource.transform.DOMove(point, conveyourResource.MoveSpeed)
            .OnComplete(() => { PointReached?.Invoke(); });
    }

    public void Dispose()
    {
        _tween?.Kill();
        input.MoveInputReceived -= OnMoveInputReceived;
    }
}