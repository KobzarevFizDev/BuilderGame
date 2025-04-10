using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BuilderGame.Cameras
{
    public class UICamera : MonoBehaviour
    {
       [field: SerializeField] public Camera Camera { private set; get; }
    }
}
