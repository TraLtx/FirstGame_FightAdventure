using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoxPowerReceiver : GameMonoBehaviour
{
    [SerializeField] protected int currentPoint = 0;
    [SerializeField] protected PowerUpgradeInventory collectInventory;

    protected override void LoadComponents(){
        this.collectInventory = transform.parent.GetComponentInChildren<PowerUpgradeInventory>();
    }

    public virtual void AddPowerUpgradePoint(int boxPower){
        this.currentPoint += boxPower;
        this.collectInventory.UpdateInventory(this.currentPoint);
    }

    public virtual int GetBoxPowerCollect(){
        return this.currentPoint;
    }
}
