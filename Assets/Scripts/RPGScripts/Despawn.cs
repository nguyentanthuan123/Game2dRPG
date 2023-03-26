using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : MonoBehaviour
{
    protected virtual void FixedUpdate()
    {
    }

    protected virtual void Despawing()
    {
        if (!this.CanDespawn()) return;
        this.Despawing();
    }

    protected virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }

    protected abstract bool CanDespawn();
}
