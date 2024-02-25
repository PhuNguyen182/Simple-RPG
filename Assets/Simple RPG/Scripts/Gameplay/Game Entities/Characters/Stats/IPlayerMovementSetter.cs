using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats
{
    public interface IPlayerMovementSetter
    {
        public void SetMoveSpeed(float speed);
        public void SetRotateSpeed(float speed);
    }
}
