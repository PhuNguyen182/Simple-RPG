using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.Characters
{
    public abstract class Character : MonoBehaviour
    {
        public abstract void InitStats(CharacterStats characterStats);
    }
}
