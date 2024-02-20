using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats
{
    public interface ICharacterUnit
    {
        public int Health { get; set; }
        public int MaxHealth { get; }
    }
}
