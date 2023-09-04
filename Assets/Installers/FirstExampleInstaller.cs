using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FirstExampleInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<MovementHandler>().AsSingle().NonLazy();
    }
}
