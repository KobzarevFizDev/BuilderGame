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
        }

        public bool IsIntersectsWithRay(Ray ray, out Vector3 point)
        {
            point = Vector3.zero;

            if (!_plane.Raycast(ray, out float enter))
                return false;

            point = ray.GetPoint(enter);
            Vector3 toPoint = point - CenterPos;

            Vector3 planeRight, planeUp;

            if (Normal == Vector3.up || Normal == -Vector3.up)
            {
                planeRight = Vector3.right;
                planeUp = Vector3.forward;
            }
            else
            {
                planeRight = Vector3.Cross(Normal, Vector3.up).normalized;
                planeUp = Vector3.Cross(planeRight, Normal).normalized;
            }

            float horizontalDist = Vector3.Dot(toPoint, planeRight);
            float verticalDist = Vector3.Dot(toPoint, planeUp);

            float halfSize = Size / 2f;
            bool withinBounds = Mathf.Abs(horizontalDist) <= halfSize &&
                               Mathf.Abs(verticalDist) <= halfSize;

            bool isFrontFace = Vector3.Dot(ray.direction, Normal) < 0;

            return withinBounds && isFrontFace;
        }


        public override string ToString()
        {
            return $"Transfrom Pos = ({CenterPos}). ID (X,Y,Z) = ({X},{Y},{Z})";
        }
    }
}
