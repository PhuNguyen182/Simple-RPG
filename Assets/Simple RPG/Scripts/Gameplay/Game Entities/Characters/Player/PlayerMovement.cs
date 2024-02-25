using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SimpleRPG.Scripts.Utils;
using SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Player
{
    public class PlayerMovement : MonoBehaviour, IPlayerMovementSetter
    {
        [SerializeField] private NavMeshAgent playerAgent;
        [SerializeField] private PlayerAnimation playerAnimation;
        [SerializeField] private LayerMask groundMask;

        private Camera _mainCamera;
        private NavMeshPath _calculatedPath;
        private Vector3 _lastRaycastResult;
        private RaycastHit _groundHitInfo;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _calculatedPath = new();
        }

        public void Move(bool isMove)
        {
            if (isMove)
                MoveCheck();

            else
                StopAgent();

            playerAnimation.PlayMovement(playerAgent.velocity.magnitude / playerAgent.speed);
        }

        private void MoveCheck()
        {
            if(_calculatedPath.status == NavMeshPathStatus.PathComplete)
            {
                // Apply path to move
                playerAgent.SetPath(_calculatedPath);
                _calculatedPath.ClearCorners();
            }

            if(GameUtils.ScreenToRay(_mainCamera, out _groundHitInfo, layerMask: groundMask))
            {
                NavMeshHit navMeshHit;
                Vector3 point = _groundHitInfo.point;

                // Preventing player move too close the clicked destination
                if (Vector3.SqrMagnitude(point - _lastRaycastResult) >= 1)
                {
                    // Find the nearest point around destination then calculate path for it
                    if (NavMesh.SamplePosition(point, out navMeshHit, 100, groundMask))
                    {
                        _lastRaycastResult = navMeshHit.position;
                        playerAgent.CalculatePath(navMeshHit.position, _calculatedPath);
                    }
                }
            }
        }

        private void StopAgent()
        {
            playerAgent.ResetPath();
            playerAgent.velocity = Vector3.zero;
        }

        public void FootstepEvent()
        {

        }

        public void SetMoveSpeed(float speed)
        {
            playerAgent.speed = speed;
        }

        public void SetRotateSpeed(float speed)
        {
            playerAgent.angularSpeed = speed;
        }
    }
}
