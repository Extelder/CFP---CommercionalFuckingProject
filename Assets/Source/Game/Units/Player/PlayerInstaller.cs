using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private PlayerConfig _config;

    public override void InstallBindings()
    {
        Container.Bind<IUnitInput>().To<MobilePlayerInput>().AsSingle();
        Container.Bind<PlayerConfig>().FromInstance(_config);

        Player player =
            Container.InstantiatePrefabForComponent<Player>(_player, _spawnPoint.position, Quaternion.identity, null);

        Container.BindInterfacesAndSelfTo<Player>().FromInstance(player).AsSingle();

        Container.BindInterfacesAndSelfTo<PlayerUnitMovementHandler>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<PlayerUnitRotationHandler>().FromNew().AsSingle().NonLazy();
    }
}