using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderGame.BuildSystem 
{
    public class WallGrid : BaseBuildGrid
    {
        private enum NormalDirection { Forward, Inverse }
        public enum WallOrientation { PlusZ, MinusZ, PlusX, MinusX }

        [SerializeField] private NormalDirection _normalDirection;

        public WallOrientation Orientation { private set; get; }

        protected override void Awake()
        {
            base.Awake();
            Orientation = GetOrientation();
        }

        public override BuildCell GetCellByCameraDirection(Ray ray)
        {
            for(int x = 0; x < _xNumberCells; x++)
            {
                for(int y = 0; y < _yNumberCells; y++)
                {
                    for(int z = 0; z < _zNumberCells; z++)
                    {
                        if(Cells[x, y, z].IsIntersectsWithRay(ray, out Vector3 point))
                        {
                            return Cells[x, y, z];
                        }
                    }
                }
            }
            return null;
        }

        protected override BuildCell CreateCell(int x, int y, int z)
        {
            Vector3 pos = GetPositionForCell(x, y, z);
            Vector3Int id = new Vector3Int(x, y, z);
            var orientation = GetOrientation();
            Vector3 normal = GetNormalForCellByOrientation(orientation);
            return new BuildCell(id, pos, normal, _cellSize);
        }

        private WallOrientation GetOrientation()
        {
            WallOrientation wallOrientation = WallOrientation.PlusZ;

            if (_xNumberCells == 1 && _zNumberCells > 1)
                wallOrientation = _normalDirection == NormalDirection.Forward ? WallOrientation.PlusZ : WallOrientation.MinusZ;
            else if (_xNumberCells > 1 && _zNumberCells == 1)
                wallOrientation = _normalDirection == NormalDirection.Forward ? WallOrientation.PlusX : WallOrientation.MinusX;
            else
                throw new System.ArgumentException("WallGrid must be one cell thick");

            return wallOrientation;
        }

        private Vector3 GetNormalForCellByOrientation(WallOrientation orientation)
        {
            switch (orientation)
            {
                case WallOrientation.PlusZ:
                    return Vector3.forward;

                case WallOrientation.MinusZ:
                    return Vector3.back;

                case WallOrientation.PlusX:
                    return Vector3.right;

                case WallOrientation.MinusX:
                    return Vector3.left;

                default:
                    throw new System.ArgumentException();
            }
        }
    }
}
