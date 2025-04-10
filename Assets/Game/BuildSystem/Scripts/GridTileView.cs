using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderGame.BuildSystem
{
    public class GridTileView : MonoBehaviour
    {
        public void SetPosition(BuildCell cell)
        {
            transform.forward = -cell.Normal;
            transform.position = cell.CenterPos - cell.Normal * cell.Size * 0.45f;
            transform.localScale = Vector3.one * cell.Size;

            //transform.forward = -Vector3.up;
            //transform.position = cell.CenterPos - Vector3.up * cell.Size * 0.45f;
            //transform.localScale = Vector3.one * cell.Size;
        }
    }
}
