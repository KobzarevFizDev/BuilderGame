using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderGame.BuildSystem
{
    public abstract class BaseBuildGrid : MonoBehaviour
    {
        [Range(1, 20)]
        [SerializeField] protected int _xNumberCells;

        [Range(2, 5)]
        [SerializeField] protected int _yNumberCells;

        [Range(1, 20)]
        [SerializeField] protected int _zNumberCells;

        public int XNumberCells => _xNumberCells;
        public int YNumberCells => _yNumberCells;
        public int ZNumberCells => _zNumberCells;

        protected const int _cellSize = 1;

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

        public BuildCell[,,] Cells { private set; get; }

        protected virtual void Awake()
        {
            CreateCells();
            AddColliderForRaycast();
        }

        private void CreateCells()
        {
            Cells = new BuildCell[_xNumberCells, _yNumberCells, _zNumberCells];

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

        protected abstract BuildCell CreateCell(int x, int y, int z);
        public abstract BuildCell GetCellByCameraDirection(Ray ray);

        protected Vector3 GetPositionForCell(int x, int y, int z)
        {
            Vector3 areaPos = transform.position;
            float xPos = 0.5f * _cellSize + x * _cellSize + areaPos.x;
            float yPos = 0.5f * _cellSize + y * _cellSize + areaPos.y;
            float zPos = 0.5f * _cellSize + z * _cellSize + areaPos.z;
            return new Vector3(xPos, yPos, zPos);
        }

    }
}
