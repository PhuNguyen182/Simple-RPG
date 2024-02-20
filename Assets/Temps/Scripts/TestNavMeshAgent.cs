using SimpleRPG.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SimpleRPG.Temps.Scripts
{
    public class TestNavMeshAgent : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private LayerMask groundMask;

        private RaycastHit _groundHitInfo;
        private Camera _mainCamera;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if(GameUtils.ScreenToRay(_mainCamera, out _groundHitInfo, layerMask: groundMask))
                {
                    agent.SetDestination(_groundHitInfo.point);
                }
            }
        }
    }
}
