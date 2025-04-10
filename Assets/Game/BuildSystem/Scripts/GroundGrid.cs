using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BuilderGame.BuildSystem
{
    public class GroundGrid : BaseBuildGrid
    {
        public int[,] HeightMap { private set; get; }

        protected override void Awake()
        {
            base.Awake();
            HeightMap = new int[_xNumberCells, _zNumberCells];

        }

        protected override BuildCell CreateCell(int x, int y, int z)
        {
            Vector3 pos = GetPositionForCell(x, y, z);
            Vector3Int id = new Vector3Int(x, y, z);
            Vector3 normal = Vector3.up;
            return new BuildCell(id, pos, normal, _cellSize);
        }

        public void AvailableToPlaceObject()
        {

        }

        // должен быть абстрактный так как зависит от конкретной сетки (на стенах нельзя размещать что угодно)
        public void PlaceObject()
        {

        }

        public void IsEmptyCell()
        {

        }

        public override BuildCell GetCellByCameraDirection(Ray ray)
        {
            for (int x = 0; x < _xNumberCells; x++)
            {
                for (int z = 0; z < _zNumberCells; z++)
                {
                    int y = HeightMap[x, z];
                    if (Cells[x, y, z].IsIntersectsWithRay(ray, out Vector3 point))
                    {
                        return Cells[x, y, z];
                    }
                }
            }
            return null;
        }

        public void ToJson()
        {

        }
    }
}
