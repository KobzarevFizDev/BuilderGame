using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BuilderGame.BuildSystem
{
    public class GridTileViewFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<GridTileViewFactory>().AsSingle().NonLazy();
        }
    }
}