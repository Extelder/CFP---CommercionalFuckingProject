using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private QueueConfig _queueConfig;
    [SerializeField] private UnitConfig _unitConfig;
    [SerializeField] private ShopContainer _shopContainer;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private GameObject _queueViewPrefab;

    public override void InstallBindings()
    {
        Container.Bind<QueueConfig>().FromInstance(_queueConfig);
        Container.Bind<UnitConfig>().FromInstance(_unitConfig);
        Container.Bind<AbstractFactory<CustomerUnitProduct>>().To<UnitFactory>()
            .AsSingle()
            .WithArguments(_unitPrefab);
        QueueView view = Container.InstantiatePrefabForComponent<QueueView>(
            _queueViewPrefab,
            _spawnPoint.position,
            Quaternion.identity,
            null);
        Container.BindInterfacesAndSelfTo<QueueView>().FromInstance(view).AsSingle();
        Container.Bind<Queue<CustomerUnitProduct>>().To<UnitQueue>().FromNew().AsSingle();
        Container.BindInterfacesAndSelfTo<QueuePurchasableHandler<CustomerUnitProduct>>().FromNew()
            .AsSingle();
        Container.Bind<ShopContainer>().FromInstance(_shopContainer).AsSingle();
        Container.Bind<Shop>().FromNew().AsSingle();
    }
}