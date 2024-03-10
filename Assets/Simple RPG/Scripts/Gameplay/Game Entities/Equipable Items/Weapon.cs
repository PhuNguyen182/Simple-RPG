using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleRPG.Scripts.Gameplay.GameEntities.Characters.Stats.Damageable;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.EquipableItems
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] protected int damage = 4;
        [SerializeField] protected float attackRange = 2f;
        [SerializeField] protected Transform attackPoint;
        [SerializeField] protected LayerMask targetMask;

        private RaycastHit[] _hitInfos = new RaycastHit[20];

        public void DamageTarget()
        {
            int count = Physics.SphereCastNonAlloc(attackPoint.position, attackRange, attackPoint.up, _hitInfos, 10, targetMask);
            if (count > 0)
            {
                for (int i = 0; i < _hitInfos.Length; i++)
                {
                    if (_hitInfos[i].transform.TryGetComponent(out IDamageable damageable))
                    {
                        damageable.TakeDamage(new DamageData
                        {
                            Damage = damage
                        });
                    }
                }
            }
        }
    }
}
