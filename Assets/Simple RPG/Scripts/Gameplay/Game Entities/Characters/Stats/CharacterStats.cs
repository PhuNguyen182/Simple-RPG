using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats.Interfaces;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats
{
    public class CharacterStats : ICharacterUnit
    {
        private int _health;
        private int _defence;
        private int _strength;
        private int _agility;
        private int _maxHealth;

        public int Health => _health;

        public int Defence => _defence;

        public int Strength => _strength;

        public int Agility => _agility;

        public int MaxHealth => _maxHealth;

        public CharacterStats(int defence, int strength, int agility)
        {
            _defence = defence;
            _strength = strength;
            _agility = agility;
        }

        public void CopyFrom(CharacterStats other)
        {
            _health = other.Health;
            _defence = other.Defence;
            _strength = other.Strength;
            _agility = other.Agility;
        }

        public void ChangeHealth(int amount)
        {
            _health = Mathf.Clamp(_health + amount, 0, _maxHealth);
        }

        public void RestoreHealth()
        {
            _health = _maxHealth;
        }

        public void SetMaxHealth(int amount)
        {
            _maxHealth = amount;
            _health = _maxHealth;
        }
    }
}
