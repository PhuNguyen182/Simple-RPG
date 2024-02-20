using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator characterAnimator;

        public static int SpeedHash = Animator.StringToHash("Speed");
        public static int AttackHash = Animator.StringToHash("Attack");
        public static int HitHash = Animator.StringToHash("Hit");
        public static int FaintHash = Animator.StringToHash("Faint");
        public static int RespawnHash = Animator.StringToHash("Respawn");

        public void PlayMovement(float speed)
        {
            characterAnimator.SetFloat(SpeedHash, speed);
        }

        public void Attack()
        {
            characterAnimator.SetTrigger(AttackHash);
        }

        public void Hit()
        {
            characterAnimator.SetTrigger(HitHash);
        }

        public void Faint()
        {
            characterAnimator.SetTrigger(FaintHash);
        }

        public void Respawn()
        {
            characterAnimator.SetTrigger(FaintHash);
        }
    }
}
