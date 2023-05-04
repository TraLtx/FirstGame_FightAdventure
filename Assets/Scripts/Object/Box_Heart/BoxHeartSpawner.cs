using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHeartSpawner : Spawner
{
    private static BoxHeartSpawner instance;
    public static BoxHeartSpawner Instance {get => instance;}

    public static string boxHeart = "Box_Heart";

    protected virtual void Awake(){
        base.Awake();
        if(instance != null) return;
        instance = this;
    }

    public virtual void SpawnBoxHeartAllPoints(){
        foreach (Transform point in this.spawnPoints)
        {
            Transform newBoxHeart = Spawn(boxHeart, point.name);
        }
    }
}
