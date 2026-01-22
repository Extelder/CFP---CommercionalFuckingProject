using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyourBeltSpawnHandler : IDisposable
{
    private ConveyourBelt _belt;
    private ConveyourBeltResourceFactory _conveyourBeltResourceFactory;

    private Transform _spawnPoint;

    private Transform[] _waypoints;

    private IConveyourBeltWaypointsContainer _conveyourBeltWaypointsContainer;

    public ConveyourBeltSpawnHandler(ConveyourBeltResourceFactory factory, ConveyourBelt belt, Transform spawnPoint,
        IConveyourBeltWaypointsContainer conveyourBeltWaypointsContainer)
    {
        _conveyourBeltResourceFactory = factory;
        _belt = belt;
        _conveyourBeltWaypointsContainer = conveyourBeltWaypointsContainer;
        _spawnPoint = spawnPoint;
        _belt.Spawn += OnBeltSpawned;
    }

    public void Dispose()
    {
        _belt.Spawn -= OnBeltSpawned;
    }

    private void OnBeltSpawned(IResourceContainerTransfer targetTransfer)
    {
        ConveyourResource conveyourResource = _conveyourBeltResourceFactory.CreateProduct(_spawnPoint.position);
        conveyourResource.StartTrackingTransfer(targetTransfer, _conveyourBeltWaypointsContainer);
    }
}