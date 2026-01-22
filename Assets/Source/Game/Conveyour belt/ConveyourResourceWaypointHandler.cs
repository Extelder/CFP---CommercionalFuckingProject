using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyourResourceWaypointHandler : IDisposable
{
    private int _currentWaypointId;

    private ConveyourResourceMoveHandler _conveyourResourceMoveHandler;
    private IConveyourBeltWaypointsContainer _conveyourBeltWaypointsContainer;
    private IConveyourResourceMoveInput _conveyourResourceMoveInput;

    public event Action AllWaypointsCleared;

    public ConveyourResourceWaypointHandler(IConveyourResourceMoveInput conveyourResourceMoveInput,
        ConveyourResourceMoveHandler conveyourResourceMoveHandler,
        IConveyourBeltWaypointsContainer conveyourBeltWaypointsContainer)
    {
        _conveyourResourceMoveHandler = conveyourResourceMoveHandler;
        _conveyourBeltWaypointsContainer = conveyourBeltWaypointsContainer;
        _conveyourResourceMoveInput = conveyourResourceMoveInput;

        _conveyourResourceMoveInput.MoveInputReceived?.Invoke(_conveyourBeltWaypointsContainer
            .Waypoints[_currentWaypointId].position);

        _conveyourResourceMoveHandler.PointReached += OnConveyourResourceMovePointReached;
    }

    private void OnConveyourResourceMovePointReached()
    {
        _currentWaypointId++;
        if (_currentWaypointId > _conveyourBeltWaypointsContainer
            .Waypoints.Length - 1)
        {
            AllWaypointsCleared?.Invoke();
            return;
        }

        _conveyourResourceMoveInput.MoveInputReceived?.Invoke(_conveyourBeltWaypointsContainer
            .Waypoints[_currentWaypointId].position);
    }

    public void Dispose()
    {
        _conveyourResourceMoveHandler.PointReached -= OnConveyourResourceMovePointReached;
    }
}