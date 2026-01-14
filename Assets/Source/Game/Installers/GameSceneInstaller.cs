using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private QueueConfig _config;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Queue _queue;

    public override void InstallBindings()
    {
        Container.Bind<QueueConfig>().FromInstance(_config);
        Queue queue =
            Container.InstantiatePrefabForComponent<Queue>(_queue, _spawnPoint.position, Quaternion.identity, null);
        Container.BindInterfacesAndSelfTo<Queue>().FromInstance(queue).AsSingle();
        Container.Bind<UnitAbstractFactory>().To<UnitAbstractFactory>().AsTransient();
    }
}