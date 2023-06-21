using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoxGunReceiver : GameMonoBehaviour
{
    [SerializeField] protected int currentPoint = 0;
    [SerializeField] protected GunUpgradeInventory collectInventory;

    protected override void LoadComponents(){
        this.collectInventory = transform.parent.GetComponentInChildren<GunUpgradeInventory>();
    }

    public virtual void AddGunUpgradePoint(int coinPoint){
        this.currentPoint += coinPoint;
        this.collectInventory.UpdateInventory(this.currentPoint);
    }

    public virtual int GetBoxGunCollect(){
        return this.currentPoint;
    }
}
