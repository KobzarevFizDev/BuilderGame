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
            BuildGrid[] grids = FindObjectsByType<BuildGrid>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            Container
                .Bind<BuildGridsRepository>()
                .AsSingle()
                .WithArguments(grids)
                .NonLazy();
        }
    }
}
