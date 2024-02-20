using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats.Damageable;
using SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable, ICharacterUnit
    {
        public int Health { get; set; }

        public int MaxHealth { get; }

        public void TakeDamage(DamageData damageData)
        {
            
        }
    }
}
