using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BuilderGame.BuildSystem
{
    public class BuildGridsRepositoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GroundGrid[] grids = FindObjectsByType<GroundGrid>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            Container
                .Bind<BuildGridsRepository>()
                .AsSingle()
                .WithArguments(grids)
                .NonLazy();
        }
    }
}
