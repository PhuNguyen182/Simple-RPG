using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleRPG.Scripts.Common.Interfaces;
using System.Linq;

namespace SimpleRPG.Scripts.GameManagers
{
    public class UpdateBehaviourManager : Singleton<UpdateBehaviourManager>
    {
        private Dictionary<int, IUpdateHandler> _updateHandles;

        protected override void OnAwake()
        {
            _updateHandles = new();
        }

        private void Update()
        {
            foreach (int key in _updateHandles.Keys)
            {
                _updateHandles[key].UpdateHandler(Time.deltaTime);
            }
        }

        public void Register(int key, IUpdateHandler handler)
        {
            if (_updateHandles.ContainsKey(key))
                _updateHandles.Add(key, handler);
        }

        public void Unregister(int key)
        {
            if (_updateHandles.ContainsKey(key))
                _updateHandles.Remove(key);
        }

        private void OnDestroy()
        {
            _updateHandles.Clear();
        }
    }
}
