using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : GameMonoBehaviour
{
    [SerializeField] protected List<Transform> spawnPoints;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected Transform holder;

    protected override void LoadComponents(){
        this.LoadSpawnPoint();
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadSpawnPoint(){
        Transform objPoints = transform.Find("SpawnPoints");
// Debug.Log("Load Spawnpoints: "+objPoints.name);
        this.spawnPoints.Clear();
        foreach (Transform point in objPoints)
        {
            spawnPoints.Add(point);
        }
    }

    protected virtual void LoadPrefabs(){
        Transform objPrefabs = transform.Find("Prefabs");

        foreach (Transform prefab in objPrefabs)
        {
            prefabs.Add(prefab);
            prefab.gameObject.SetActive(false);
        }
    }

    protected virtual void LoadHolder(){
        if(this.holder != null) return;

        this.holder = transform.Find("Holder");
    }

    protected virtual Transform GetPrefabByName(string name){
        foreach (Transform prefab in prefabs)
        {
            if(name == prefab.name) return prefab;
        }
        return null;
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
}
