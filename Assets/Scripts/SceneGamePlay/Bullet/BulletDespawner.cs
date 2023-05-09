using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawner : DespawnerByDistance
{
    public override void Despawn(){
        // Debug.Log("Back bullet to pool!");
        BulletSpawner.Instance.BackObjToPool(transform.parent);
    }
}
