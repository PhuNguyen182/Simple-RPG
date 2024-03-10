using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SimpleRPG.Scripts.Gameplay.GameEntities.InventoryItems
{
    public abstract class Item : ScriptableObject
    {
        [SerializeField] protected string itemName;
        [SerializeField] protected Sprite itemIcon;
        [SerializeField] protected string description;
        [SerializeField] protected GameObject worldPrefab;

        public virtual string GetDescription() => description;
    }
}
