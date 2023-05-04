using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public abstract class SpawnerWithPool : GameMonoBehaviour
{
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected Transform holder;

    protected override void LoadComponents(){
        this.LoadHolder();
        this.LoadPrefabs();
    }

    protected virtual void LoadHolder(){
        if(this.holder != null) return;

        this.holder = transform.Find("Holder");
    }

    protected virtual void LoadPrefabs()
    {
        if(prefabs.Count > 0) return;

        Transform prefabsObject = transform.Find("Prefabs");
        Debug.Log("LoadPrefabs: "+prefabsObject);
        foreach (Transform prefab in prefabsObject)
        {
            prefabs.Add(prefab);
        }

        this.HidePrefabs();
    }

    protected virtual void HidePrefabs(){
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public Transform Spawn(string prefabName, Vector3 position, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if(prefab == null){
            Debug.LogWarning("Can not find prefab by name: " + prefabName);
            return null;
        }

        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(position, rotation);

        return newPrefab;
    }

    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach(Transform prefab in prefabs){
            if(prefabName == prefab.name){
                return prefab;
            }
        }

        return null;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab){
        foreach (Transform poolObj in poolObjs)
        {
            if(prefab.name == poolObj.name){
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = null;
        if(GameController.Instance.IsOnlineState){
            // newPrefab = PhotonNetwork.Instantiate(prefab.name);
        }else{
            newPrefab = Instantiate(prefab);
        }
        
        newPrefab.name = prefab.name;
        newPrefab.parent = this.holder;
        return newPrefab;
    }

    public virtual void BackObjToPool(Transform obj){
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }
}
