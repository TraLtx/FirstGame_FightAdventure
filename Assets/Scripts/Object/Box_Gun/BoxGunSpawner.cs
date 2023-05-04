using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGunSpawner : Spawner
{
    private static BoxGunSpawner instance;
    public static BoxGunSpawner Instance {get => instance;}

    public static string boxGun = "Box_GunUp";

    protected virtual void Awake(){
        base.Awake();
        if(instance != null) return;
        instance = this;
    }

    public virtual void SpawnBoxGunAllPoints(){
        foreach (Transform point in this.spawnPoints)
        {
            Transform newBoxGun = Spawn(boxGun, point.name);
        }
    }
}
