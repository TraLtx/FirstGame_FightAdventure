using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnerByDistance : Despawner
{
    [SerializeField] protected float distanceLimit;
    [SerializeField] protected float distance;
    [SerializeField] Camera mainCamera;

    protected override void LoadComponents(){
        this.LoadCamera();
        this.LoadData();
    }

    protected virtual void LoadCamera(){
        if(this.mainCamera != null) return;

        this.mainCamera = Transform.FindObjectOfType<Camera>();
    }

    protected virtual void LoadData(){
        distanceLimit = 70f;
        distance = 0f;
    }

    protected override bool IsDespawnAble(){
        this.distance = Vector3.Distance(transform.position, mainCamera.transform.position);
        // Debug.Log("Distance of bullet: "+this.distance);
        if(distance < distanceLimit) return false;
        return true;
    }
}
