using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : GameMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected Transform holder;

    protected override void LoadComponents(){
        this.LoadPrefabs();
        this.LoadHolder();
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

    protected virtual Transform GetPrefabByName(string prefabName){
        foreach (Transform prefab in prefabs)
        {
            if(prefabName == prefab.name) return prefab;
        }
        return null;
    }

    // public abstract Transform Spawn();

}
