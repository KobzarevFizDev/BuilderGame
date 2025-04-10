using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace BuilderGame.BuildSystem
{
    public class RaycastTarget : MonoBehaviour
    {
        public BuildCell Cell { private set; get; }
        public BuildGrid Area { private set; get; }

        private GameObject _hoverIndicator;
        private MeshRenderer _meshRenderer;

        public void Initialize(BuildCell cell, BuildGrid area)
        {
            Cell = cell;
            Area = area;
            _hoverIndicator = CreateHoverIndicator();
            _meshRenderer = _hoverIndicator.GetComponent<MeshRenderer>();
            Unselect();
        } 

        private GameObject CreateHoverIndicator()
        {
            var indicator = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Destroy(indicator.GetComponent<BoxCollider>());
            indicator.transform.localScale = Vector3.one * 0.8f;
            indicator.transform.position = Cell.CenterPos;
            return indicator;
        }
        
        public void Select()
        {
            Color c = _meshRenderer.material.color;
            c.a = 255;
            _meshRenderer.material.color = c;
        }

        public void Unselect()
        {
            Color c = _meshRenderer.material.color;
            c.a = 0;
            _meshRenderer.material.color = c;
        }
    }
}