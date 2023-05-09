using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerNormal : Spawner
{
    [SerializeField] protected List<Transform> spawnPoints;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadSpawnPoint();
    }

    protected virtual void LoadSpawnPoint(){
        Transform objPoints = transform.Find("SpawnPoints");
        this.spawnPoints.Clear();
        foreach (Transform point in objPoints)
        {
            spawnPoints.Add(point);
        }
    }

    protected virtual Transform GetSpawnPointByName(string name){
        foreach (Transform point in spawnPoints)
        {
            if(name == point.name) return point;
        }
        return null;
    }
    
    public virtual Transform Spawn(string prefabName, string spawnPointName){
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

        Transform newObject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        newObject.gameObject.SetActive(true);
        newObject.parent = this.holder;
        return newObject;
    }

    public virtual int CountSpawnPoint(){
        return this.spawnPoints.Count;
    }
}
