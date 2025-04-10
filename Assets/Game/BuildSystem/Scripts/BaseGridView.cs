using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BuilderGame.BuildSystem
{

    public class BaseGridView : MonoBehaviour
    {
        protected GridTileViewFactory _factory;
        protected GridTileView[,] _planes;

        [Inject]
        private void Constructor(GridTileViewFactory factory)
        {
            _factory = factory;
        }
    }
}
