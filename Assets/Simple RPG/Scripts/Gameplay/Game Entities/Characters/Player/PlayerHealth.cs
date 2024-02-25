using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats.Damageable;
using SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable, ICharacterUnit
    {
        private int _health = 0;
        private int _maxHealth = 0;

        public int Health => _health;

        public int MaxHealth => _maxHealth;

        public void Die()
        {
            
        }

        public void RestoreHealth()
        {
            
        }

        public void SetMaxHealth(int health)
        {
            _maxHealth = health;
            _health = health;
        }

        public void TakeDamage(DamageData damageData)
        {
            _health = _health - damageData.Damage;
            
            if(_health <= 0)
            {
                _health = 0;
                Die();
            }
        }
    }
}
