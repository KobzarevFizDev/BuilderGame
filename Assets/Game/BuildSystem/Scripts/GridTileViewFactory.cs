using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderGame.BuildSystem
{
    public class GridTileViewFactory
    {
        private const string PATH_TO_PREFAB = "GridTileView";

        private GridTileView _prefab;
        public GridTileViewFactory()
        {
            _prefab = Resources.Load<GridTileView>(PATH_TO_PREFAB);
            if (_prefab == null)
                throw new System.ArgumentException("Incorrect path to prefab");
        }

        public GridTileView Create(BuildCell cell)
        {
            var tileView = GameObject.Instantiate<GridTileView>(_prefab);
            tileView.SetPosition(cell);
            return tileView;
        }
    }
}
