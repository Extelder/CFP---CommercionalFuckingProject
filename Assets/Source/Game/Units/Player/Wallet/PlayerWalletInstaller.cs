using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerWalletInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerWallet>().AsSingle().WithArguments(0, 100, 0);
    }
}