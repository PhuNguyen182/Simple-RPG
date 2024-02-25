using SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Player 
{
    public class PlayerController : MonoBehaviour, IPlayerMovementSetter, ICharacterAttack
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private PlayerAttack playerAttack;

        private void Update()
        {
            if (playerInput.Attack)
            {
                Attack();
            }

            playerMovement.Move(playerInput.IsMousePressed);
        }

        public void Attack()
        {
            playerAttack.Attack();
        }

        public void SetMoveSpeed(float speed)
        {
            playerMovement.SetMoveSpeed(speed);
        }

        public void SetRotateSpeed(float speed)
        {
            playerMovement.SetRotateSpeed(speed);
        }
    }
}
