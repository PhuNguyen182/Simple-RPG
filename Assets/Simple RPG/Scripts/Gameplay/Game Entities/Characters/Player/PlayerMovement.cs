using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SimpleRPG.Scripts.Utils;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private NavMeshAgent playerAgent;
        [SerializeField] private PlayerAnimation playerAnimation;
        [SerializeField] private LayerMask groundMask;

        private Camera _mainCamera;
        private RaycastHit _groundHitInfo;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            PlayerMove();
        }

        private void PlayerMove()
        {
            if (playerInput.IsMousePressed && GameUtils.ScreenToRay(_mainCamera, out _groundHitInfo, layerMask: groundMask))
            {
                playerAgent.isStopped = false;
                playerAgent.SetDestination(_groundHitInfo.point);
            }
            else
                playerAgent.isStopped = true;

            playerAnimation.PlayMovement(playerAgent.velocity.magnitude / playerAgent.speed);
        }

        public void FootstepEvent()
        {

        }
    }
}
