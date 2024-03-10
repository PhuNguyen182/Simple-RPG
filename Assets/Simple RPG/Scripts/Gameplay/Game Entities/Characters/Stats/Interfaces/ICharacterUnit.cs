using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats.Interfaces
{
    public interface ICharacterUnit
    {
        public int Health { get; }
        public int Defence { get; }
        public int Strength { get; }
        public int Agility { get; }
        public int MaxHealth { get; }

        public void SetMaxHealth(int amount);
        public void CopyFrom(CharacterStats other);
    }
}
