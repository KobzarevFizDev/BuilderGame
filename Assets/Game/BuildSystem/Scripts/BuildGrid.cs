using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BuilderGame.BuildSystem
{
    public class BuildGrid : MonoBehaviour
    {
        [Range(2, 20)]
        [SerializeField] private int _xNumberCells;

        [Range(2, 5)]
        [SerializeField] private int _yNumberCells;

        [Range(2, 20)]
        [SerializeField] private int _zNumberCells;

        public BuildCell[,,] Cells { private set; get; }
        public int[,] HeightMap { private set; get; }

        public int XNumberCells => _xNumberCells;
        public int YNumberCells => _yNumberCells;
        public int ZNumberCells => _zNumberCells;

        public float XSize
        {
            get
            {
                return (Cells[_xNumberCells - 1, 0, 0].CenterPos - Cells[0, 0, 0].CenterPos).x + _cellSize;
            }
        }

        public float ZSize
        {
            get
            {
                return (Cells[0, 0, _zNumberCells - 1].CenterPos - Cells[0, 0, 0].CenterPos).z + _cellSize;
            }
        }

        public float YSize
        {
            get
            {
                return (Cells[0, _yNumberCells - 1, 0].CenterPos - Cells[0, 0, 0].CenterPos).y + _cellSize;
            }
        }


        private const int _cellSize = 1;


        private void Awake()
        {
            CreateCells();
            AddColliderForRaycast();
        }

        private void CreateCells()
        {
            Cells = new BuildCell[_xNumberCells, _yNumberCells, _zNumberCells];
            HeightMap = new int[_xNumberCells, _zNumberCells];

            for (int x = 0; x < _xNumberCells; x++)
            {
                for (int y = 0; y < _yNumberCells; y++)
                {
                    for (int z = 0; z < _zNumberCells; z++)
                    {
                        BuildCell cell = CreateCell(x, y, z);
                        Cells[x, y, z] = cell;
                    }
                }
            }
        }

        private void AddColliderForRaycast()
        {
            var collider = gameObject.AddComponent<BoxCollider>();
            collider.size = new Vector3(XSize, YSize, ZSize);
            collider.center = new Vector3(XSize / 2, YSize / 2, ZSize / 2);
            gameObject.layer = LayerMask.NameToLayer("BuildGrid");
        }

        private BuildCell CreateCell(int x, int y, int z)
        {
            Vector3 areaPos = transform.position;
            float xPos = 0.5f * _cellSize + x * _cellSize + areaPos.x;
            float yPos = 0.5f * _cellSize + y * _cellSize + areaPos.y;
            float zPos = 0.5f * _cellSize + z * _cellSize + areaPos.z;
            var transfromPos = new Vector3(xPos, yPos, zPos);
            return new BuildCell(x, y, z, transfromPos, _cellSize);
        }


        public void AvailableToPlaceObject()
        {

        }

        public void PlaceObject()
        {

        }

        public void IsEmptyCell()
        {

        }

        public BuildCell GetCellByCameraDirection(Ray ray)
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
