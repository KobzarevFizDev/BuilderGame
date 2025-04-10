using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderGame.BuildSystem
{
    public enum CellType { OnGround, OnWall }

    public class BuildCell 
    {
        public int X { private set; get; }
        public int Y { private set; get; }
        public int Z { private set; get; }
        public Vector3 CenterPos { private set; get; }
        public Vector3 Normal { private set; get; }

        public float Size { private set; get; }

        private Plane _plane;
        public BuildCell(Vector3Int id, Vector3 pos, Vector3 normal, float size)
        {
            X = id.x;
            Y = id.y;
            Z = id.z;
            CenterPos = pos;
            Normal = normal;
            Size = size;

            _plane = new Plane(normal, pos - 0.5f * normal * Size);
            //_plane = new Plane(Vector3.up, pos - Vector3.up * Size * 0.5f);
        }

        public bool IsIntersectsWithRay(Ray ray, out Vector3 point)
        {
            point = Vector3.zero;

            if (_plane.Raycast(ray, out float enter))
            {
                point = ray.GetPoint(enter);

                float halfSize = Size / 2f;
                bool isInsideX = point.x >= CenterPos.x - halfSize && point.x <= CenterPos.x + halfSize;
                bool isInsideZ = point.z >= CenterPos.z - halfSize && point.z <= CenterPos.z + halfSize;

                return isInsideX && isInsideZ;
            }

            return false;
        }

        public override string ToString()
        {
            return $"Transfrom Pos = ({CenterPos}). ID (X,Y,Z) = ({X},{Y},{Z})";
        }
    }
}
