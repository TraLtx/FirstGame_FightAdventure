using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGrenadeSpawner : SpawnerNormal
{
    private static EnemyGrenadeSpawner instance;
    public static EnemyGrenadeSpawner Instance {get => instance;}

    public static string enemy = "Enemy_Grenade";

    protected virtual void Awake(){Debug.Log("instance");
        base.Awake();
        if(instance != null) return;
        instance = this;
    }

    public virtual void SpawnEnemyAllPoints(){
        foreach (Transform point in this.spawnPoints)
        {
            Transform newEnemy = Spawn(enemy, point.name);
            
            Physics2D.IgnoreCollision(GameController.Instance.ThisPlayer.GetComponent<Collider2D>(),
            newEnemy.GetComponent<Collider2D>());
        }
    }
}
