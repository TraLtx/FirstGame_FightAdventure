using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : Spawner
{
    private static PlayerSpawner instance;
    public static PlayerSpawner Instance {get => instance;}

    public static string player = "Player";
    public static string spawnPointServer = "PlayerSpawnPoint_1";
    public static string spawnPointClient = "PlayerSpawnPoint_2";

    protected virtual void Awake(){
        // base.Awake();
        if(instance != null) return;
        instance = this;
    }

}
