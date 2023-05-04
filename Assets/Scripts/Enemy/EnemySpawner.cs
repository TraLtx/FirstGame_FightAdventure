using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance {get => instance;}

    public static string enemy = "Enemy";
    public static string spawnPointMiddle = "EnemySpawnPoint_1";
    public static string spawnPointTopLeft = "EnemySpawnPoint_2";
    public static string spawnPointTopRight = "EnemySpawnPoint_3";
    public static string spawnPointBotLeft = "EnemySpawnPoint_4";
    public static string spawnPointBotRight = "EnemySpawnPoint_5";


    protected virtual void Awake(){Debug.Log("instance");
        base.Awake();
        if(instance != null) return;
        instance = this;
    }

    public virtual void SpawnEnemyAllPoints(){
        foreach (Transform point in this.spawnPoints)
        {
            Transform newEnemy = Spawn(enemy, point.name);
            newEnemy.GetComponent<EnemyCtrl>().SetThisSpawnPoint(point);
            Physics2D.IgnoreCollision(GameController.Instance.ThisPlayer.GetComponent<Collider2D>(),
            newEnemy.GetComponent<Collider2D>());
        }
    }

}
