using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public bool IsMouseClicked { get; private set; }

        private void Update()
        {
            IsMouseClicked = Input.GetMouseButtonDown(0);
        }
    }
}
