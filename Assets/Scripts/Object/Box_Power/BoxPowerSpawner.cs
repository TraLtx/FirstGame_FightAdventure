using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPowerSpawner : Spawner
{
    private static BoxPowerSpawner instance;
    public static BoxPowerSpawner Instance {get => instance;}

    public static string boxPower = "Box_Power";

    protected virtual void Awake(){
        base.Awake();
        if(instance != null) return;
        instance = this;
    }

    public virtual void SpawnBoxPowerAllPoints(){
        foreach (Transform point in this.spawnPoints)
        {
            Transform newBoxPower = Spawn(boxPower, point.name);
        }
    }
}
