using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerSpawner : SpawnerNormal
{
    private static PlayerSpawner instance;
    public static PlayerSpawner Instance {get => instance;}

    public static string player = "Player";
    public static string player_2 = "Player_2";
    public static string spawnPointServer = "PlayerSpawnPoint_1";
    public static string spawnPointClient = "PlayerSpawnPoint_2";

    protected virtual void Awake(){
        // base.Awake();
        if(instance != null) return;
        instance = this;
    }

    public override Transform Spawn(string prefabName, string spawnPointName){
        Transform prefab = this.GetPrefabByName(prefabName);
        if(prefab == null){
            Debug.LogWarning("Can not found this prefabName: " + prefabName);
            return null;
        }

        Transform spawnPoint = this.GetSpawnPointByName(spawnPointName);
        if(spawnPoint == null){
            Debug.LogWarning("Can not found this spawnPointName: " + spawnPointName);
            return null;
        }

        prefab.gameObject.SetActive(true);
        prefab.position = spawnPoint.position;
        return prefab;

        // Transform newObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        // newObject.gameObject.SetActive(true);
        // newObject.parent = this.holder;
        // return newObject;
    }

}
