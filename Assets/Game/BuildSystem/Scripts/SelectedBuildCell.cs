using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using BuilderGame.Cameras;

namespace BuilderGame.BuildSystem
{
    public class SelectedBuildCell : MonoBehaviour
    {
        private PlayerCamera _playerCamera;
        private const float _maxDistanceToRaycast = 10f;

        //private RaycastTarget _currentSelectedCell;

        //public RaycastTarget CurrentSelectedCell
        //{
        //    get
        //    {
        //        return _currentSelectedCell;
        //    }

        //    private set
        //    {
        //        if(value == null || _currentSelectedCell != value) // «начит нужно убрать выделение с €чейки если оно не null
        //        {
        //            if (_currentSelectedCell != null)
        //            {
        //                print("— прошлой €чейки убираем выделение");
        //                _currentSelectedCell.Unselect();
        //            }
        //            if (value != null)
        //            {
        //                print("¬ыдел€ем новую €чейку");
        //                value.Select();
        //            }
        //            _currentSelectedCell = value;
        //        }

        //    }
        //}

        private GameObject _marker;
        private BuildGridsRepository _buildGrids;

        [Inject]
        private void Constructor(PlayerCamera playerCamera, BuildGridsRepository buildGrids)
        {
            _playerCamera = playerCamera;
            _buildGrids = buildGrids;
        }

        void Start()
        {
            _marker = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Destroy(_marker.GetComponent<BoxCollider>());
            _marker.name = "MARKER";
            _marker.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        void FixedUpdate()
        {
            if (CheckBuildCell(out BuildCell cell))
            {
                _marker.transform.position = cell.CenterPos;
            }
        }

        private bool CheckBuildCell(out BuildCell cell)
        {
            cell = null;
            Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
            Ray ray = _playerCamera.Camera.ScreenPointToRay(center);
            int layerMask = 1 << LayerMask.NameToLayer("BuildGrid");
            if (Physics.Raycast(ray, out RaycastHit hit, 10f, layerMask, QueryTriggerInteraction.Ignore))
            {
                DebugExtension.DebugPoint(hit.point);
                var buildGrid = hit.transform.gameObject.GetComponent<BaseBuildGrid>();
                cell = buildGrid.GetCellByCameraDirection(ray);
                if (cell != null)
                    return true;
                else
                    return false;
            }
            else
            {
                cell = _buildGrids.GetCellByCameraDirection(ray);
                if (cell != null)
                    return true;
                else
                    return false;
            }
        }
    }
}
