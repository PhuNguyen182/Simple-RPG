using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats.Damageable;
using SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Player
{
    public class CharacterHealth : MonoBehaviour, IDamageable
    {
        private CharacterStats _characterStats;

        public Action OnDie;
        public Action OnRestore;
        public Action<DamageData> OnChangeHealth;

        public void Init(CharacterStats stats)
        {
            _characterStats.CopyFrom(stats);
        }

        public void Die()
        {
            OnDie?.Invoke();
        }

        public void RestoreHealth()
        {
            OnRestore?.Invoke();
        }

        public void TakeDamage(DamageData damageData)
        {
            OnChangeHealth?.Invoke(damageData);
            _characterStats.ChangeHealth(-damageData.Damage);
        }
    }
}
