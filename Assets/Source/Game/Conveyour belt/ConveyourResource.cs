using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConveyourResource : AbstractProduct, IConveyourResourceMoveInput
{
    [field: SerializeField] public float MoveSpeed { get; private set; }

    public Action<Vector3> MoveInputReceived { get; set; }

    public override event Action Initialized;

    private ConveyourResourceWaypointHandler _conveyourResourceWaypointHandler;

    private IResourceContainerTransfer _targetResourceContainerTransfer;

    public override void Init()
    {
    }

    public void StartTrackingTransfer(IResourceContainerTransfer targetConveyourResourceContainerTransfer,
        IConveyourBeltWaypointsContainer conveyourBeltWaypointsContainer)
    {
        _targetResourceContainerTransfer = targetConveyourResourceContainerTransfer;

        ConveyourResourceMoveHandler conveyourResourceMoveHandler = new ConveyourResourceMoveHandler(this, this);

        _conveyourResourceWaypointHandler =
            new ConveyourResourceWaypointHandler(this, conveyourResourceMoveHandler, conveyourBeltWaypointsContainer);
        _conveyourResourceWaypointHandler.AllWaypointsCleared += OnAllWaypointsCleared;
    }

    private void OnAllWaypointsCleared()
    {
        _targetResourceContainerTransfer.ResourceContainer.TryAdd(1,
            _targetResourceContainerTransfer.ResourceContainer.ResourcesType);
        Dispose();
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        Dispose();
    }

    public void Dispose()
    {
        _conveyourResourceWaypointHandler.Dispose();
        _conveyourResourceWaypointHandler.AllWaypointsCleared -= OnAllWaypointsCleared;
    }
}