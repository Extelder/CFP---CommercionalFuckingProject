using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class ConveyourBelt : MonoBehaviour, IConveyourBeltWaypointsContainer
{
    [field: SerializeField] public Transform[] Waypoints { get; set; }

    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private float _spawnRate;

    [SerializeField] private MonoBehaviour _takeFromResourceContainerTransfer;
    [SerializeField] private MonoBehaviour _giveToResourceContainerTransfer;

    [Inject] private DiContainer _container;

    private bool _spawning;

    private int _resourcesToSpawn = 0;

    private CompositeDisposable _disposable = new CompositeDisposable();

    private IConveyourResourceContainerTransfer _takeContainer =>
        _takeFromResourceContainerTransfer as IConveyourResourceContainerTransfer;

    private IResourceContainerTransfer _giveContainer => _giveToResourceContainerTransfer as IResourceContainerTransfer;

    public event Action<IResourceContainerTransfer> Spawn;

    private ConveyourBeltSpawnHandler _conveyourBeltSpawnHandler;
    
    private void OnEnable()
    {
        _takeContainer.ResourceContainer.Added += OnResourcesAddedFromTakeContainer;
        _conveyourBeltSpawnHandler =
            new ConveyourBeltSpawnHandler(new ConveyourBeltResourceFactory(_takeContainer.ConveyourResource, _container), this,
                _spawnPoint, this);
    }

    private void OnResourcesAddedFromTakeContainer(int value)
    {
        _resourcesToSpawn += value;

        if (_spawning)
            return;

        _spawning = true;

        Observable.Interval(TimeSpan.FromSeconds(_spawnRate)).Subscribe(_ =>
        {
            Spawn?.Invoke(_giveContainer);
            _takeContainer.ResourceContainer.TryRemove(1);
            _resourcesToSpawn--;

            if (_resourcesToSpawn == 0)
            {
                _spawning = false;
                _disposable.Clear();
            }
        }).AddTo(_disposable);
    }

    private void OnDisable()
    {
        _conveyourBeltSpawnHandler.Dispose();
        _disposable?.Clear();
        _takeContainer.ResourceContainer.Added -= OnResourcesAddedFromTakeContainer;
    }
}