using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawner : GameMonoBehaviour
{
    protected virtual void FixedUpdate(){
        this.DespawnCheck();
    }

    protected virtual void DespawnCheck(){
        if(!this.IsDespawnAble()) return;

        this.Despawn();
    }

    public virtual void Despawn(){
        // Destroy(transform.parent.gameObject);
    }

    protected abstract bool IsDespawnAble();
}
