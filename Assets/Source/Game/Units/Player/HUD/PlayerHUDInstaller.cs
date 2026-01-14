using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerHUDInstaller : MonoInstaller
{
    [SerializeField] private PlayerHUD _playerHud;
    [SerializeField] private Transform _spawnPoint;

    public override void InstallBindings()
    {
        PlayerHUD playerHud =
            Container.InstantiatePrefabForComponent<PlayerHUD>(_playerHud, _spawnPoint.position, Quaternion.identity,
                null);

        Container.Bind<PlayerHUD>().FromInstance(playerHud).AsSingle();
    }
}