using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace BuilderGame.BuildSystem
{
    public class BuildGridView : MonoBehaviour
    {
        [SerializeField] private BuildGrid _buildGrid;

        private GridTileView[,] _planes;

        private GridTileViewFactory _factory;

        [Inject]
        private void Constructor(GridTileViewFactory factory)
        {
            _factory = factory;
        }

        private void Start()
        {
            _planes = new GridTileView[_buildGrid.XNumberCells, _buildGrid.ZNumberCells];


            for(int x = 0; x < _buildGrid.XSize; x++)
            {
                for (int z = 0; z < _buildGrid.ZSize; z++)
                {
                    int y = _buildGrid.HeightMap[x, z];
                    BuildCell cell = _buildGrid.Cells[x, y, z];
                    _planes[x, z] = _factory.Create(cell);
                }
            }
        }
    }
}
