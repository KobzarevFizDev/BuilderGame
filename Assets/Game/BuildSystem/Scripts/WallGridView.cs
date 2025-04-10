using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderGame.BuildSystem 
{

    public class WallGridView : BaseGridView
    {
        [SerializeField] private WallGrid _grid;
        private WallGrid.WallOrientation _orientation;

        private void Start()
        {
            _orientation = _grid.Orientation;
            print($"Orientation: {_orientation}");
            CalculateWallSize(out int UNumberCells, out int VNumberCells);
            _planes = new GridTileView[UNumberCells, VNumberCells];

            for(int u = 0; u < UNumberCells; u++)
            {
                for (int v = 0; v < VNumberCells; v++)
                {
                    BuildCell cell = GetCellByUV(u, v);
                    _planes[u, v] = _factory.Create(cell);
                }
            }
        }

        // todo: Скорее увсего нужно написать функцию перевода X Y Z в U V координаты
        // U - Координата по высоте стены
        // V - Координата вдоль стены
        private void CalculateWallSize(out int UNumberCells, out int VNumberCells)
        {
            UNumberCells = _grid.YNumberCells;
            VNumberCells = -1;

            if (_orientation == WallGrid.WallOrientation.PlusZ || _orientation == WallGrid.WallOrientation.MinusZ)
            {
                VNumberCells = _grid.ZNumberCells;
            }
            else if (_orientation == WallGrid.WallOrientation.PlusX || _orientation == WallGrid.WallOrientation.MinusX)
            {
                VNumberCells = _grid.XNumberCells;
            }
            else
            {
                throw new System.ArgumentException("Incorrect wall orientation");
            }
        }

        private BuildCell GetCellByUV(int u, int v)
        {
            int y = u;
            int x = 0;
            int z = 0;
            if(_orientation == WallGrid.WallOrientation.PlusZ || _orientation == WallGrid.WallOrientation.MinusZ)
            {
                z = v;
                return _grid.Cells[x, y, z];
            }
            else if(_orientation == WallGrid.WallOrientation.PlusX || _orientation == WallGrid.WallOrientation.MinusX)
            {
                x = v;
                return _grid.Cells[x, y, z];
            }
            else
            {
                throw new System.ArgumentException("Incorrect wall orientation");
            }
        }
    }
}