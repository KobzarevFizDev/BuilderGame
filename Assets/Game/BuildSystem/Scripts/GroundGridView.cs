using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BuilderGame.BuildSystem
{
    public class GroundGridView : BaseGridView
    {
        [SerializeField] private GroundGrid _grid;

        private void Start()
        {
            _planes = new GridTileView[_grid.XNumberCells, _grid.ZNumberCells];

            for(int x = 0; x < _grid.XSize; x++)
            {
                for (int z = 0; z < _grid.ZSize; z++)
                {
                    int y = _grid.HeightMap[x, z];
                    BuildCell cell = _grid.Cells[x, y, z];
                    _planes[x, z] = _factory.Create(cell);
                }
            }
        }
    }
}
