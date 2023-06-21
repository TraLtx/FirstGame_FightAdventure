using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public abstract class SpawnerWithPool : Spawner
{
    [SerializeField] protected List<Transform> poolObjs;

    protected override void LoadComponents(){
        base.LoadComponents();
    }

    public Transform Spawn(string prefabName, Vector3 position, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if(prefab == null){
            Debug.LogWarning("Can not find prefab by name: " + prefabName);
            return null;
        }

        Transform newPrefab = this.GetObjectFromPool(prefab);
        // newPrefab.transform.position = position;
        newPrefab.SetPositionAndRotation(position, rotation);

        return newPrefab;
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
