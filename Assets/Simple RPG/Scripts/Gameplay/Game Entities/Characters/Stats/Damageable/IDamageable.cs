using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats.Damageable
{
    public interface IDamageable
    {
        public void Die();
        public void TakeDamage(DamageData damageData);
        public void RestoreHealth();
    }
}
