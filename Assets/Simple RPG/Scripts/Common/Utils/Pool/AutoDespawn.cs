using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleRPG.Scripts.Common.Interfaces;
using SimpleRPG.Scripts.GameManagers;

public class AutoDespawn : MonoBehaviour, IUpdateHandler
{
    [SerializeField] private bool hasContainer;
    [SerializeField] private float duration;

    private int _instanceID;
    private float timer = 0;

    private void Awake()
    {
        _instanceID = gameObject.GetInstanceID();
    }

    private void OnEnable()
    {
        timer = 0;
        UpdateBehaviourManager.Instance.Register(_instanceID, this);
    }

    public void UpdateHandler(float deltaTime)
    {
        timer += deltaTime;
        if(timer > duration)
        {
            SimplePool.Despawn(this.gameObject);
        }
    }

    public void SetDuration(float duration) => this.duration = duration;

    private void OnDisable()
    {
        UpdateBehaviourManager.Instance.Unregister(_instanceID);
    }
}
