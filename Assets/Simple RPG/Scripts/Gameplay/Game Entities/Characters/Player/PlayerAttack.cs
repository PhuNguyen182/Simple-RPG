using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private float cooldown = 0.25f;
        [SerializeField] private PlayerAnimation playerAnimation;

        private float _attackCooldown = 0;

        public void Attack()
        {
            if(_attackCooldown < Time.time)
            {
                _attackCooldown = Time.time + cooldown;
                playerAnimation.Attack();
            }
        }

        public void AttackEvent()
        {

        }
    }
}
