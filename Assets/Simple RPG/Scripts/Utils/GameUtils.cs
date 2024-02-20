using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleRPG.Scripts.Utils
{
    public static class GameUtils
    {
        public static bool ScreenToRay(Camera camera, out RaycastHit hitInfo, float maxDistance = 50, LayerMask layerMask = default)
        {
            Ray screenRay = camera.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(screenRay, out hitInfo, maxDistance, layerMask);
        }

        public static Vector3 ScreenToWorld(Camera camera)
        {
            return camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
