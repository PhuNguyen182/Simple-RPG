using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats.Interfaces;
using SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats;
using SimpleRPG.Scripts.Common.Interfaces;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Player 
{
    public class Player : Character, IPlayerMovementSetter, ICharacterAttack
    {
        [Header("Player Components")]
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private CharacterHealth playerHealth;
        [SerializeField] private PlayerAttack playerAttack;

        [Space(10)]
        [SerializeField] private LayerMask interactiveCheckMask;
        [SerializeField] private LayerMask targetCheckMask;

        private IInteractiveObject _hightLight;
        private RaycastHit[] _checkHits = new RaycastHit[10];

        public CharacterHealth PlayerHealth => playerHealth;

        private void Awake()
        {
            TestInit();
        }

        private void Update()
        {
            if (playerInput.Attack)
            {
                Attack();
            }

            playerMovement.Move(playerInput.IsMousePressed);
        }

        private void TestInit()
        {
            CharacterStats stats = new(1, 1, 1);
            stats.SetMaxHealth(100);
            InitStats(stats);
        }

        public void Attack()
        {
            playerAttack.Attack();
        }

        public void SetMoveSpeed(float speed)
        {
            playerMovement.SetMoveSpeed(speed);
        }

        public void SetRotateSpeed(float speed)
        {
            playerMovement.SetRotateSpeed(speed);
        }

        public override void InitStats(CharacterStats characterStats)
        {
            playerHealth.Init(characterStats);
        }

        private void CheckAttack(Ray checkRay)
        {
            // Check if player close to target
            int hitCount = Physics.SphereCastNonAlloc(checkRay, 1.5f, _checkHits, 100f, interactiveCheckMask);
            
            if(hitCount > 0)
            {
                // Check for interactive objects
                for (int i = 0; i < _checkHits.Length; i++)
                {
                    if (_checkHits[i].collider.TryGetComponent<IInteractiveObject>(out var interactiveObject))
                    {
                        SwitchHightLightObject(interactiveObject);
                        break;
                    }
                }
            }
            else
            {
                hitCount = Physics.SphereCastNonAlloc(checkRay, 1.5f, _checkHits, 100f, targetCheckMask);
                if(hitCount > 0)
                {
                    if (_checkHits[0].collider.TryGetComponent<Character>(out var character))
                    {
                        
                    }
                }
            }
        }

        private void SwitchHightLightObject(IInteractiveObject interactiveObject)
        {
            _hightLight?.DehightLight();
            _hightLight = interactiveObject;
            _hightLight?.HighLight();
        }
    }
}
