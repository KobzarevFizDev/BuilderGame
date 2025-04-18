using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BuilderGame.Cameras
{
    public class CamerasInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<PlayerCamera>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<UICamera>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}
