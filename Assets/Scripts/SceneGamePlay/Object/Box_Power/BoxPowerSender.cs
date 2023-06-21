using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoxPowerSender : GameMonoBehaviour
{
    [SerializeField] protected int powerUpgradePoint = 1;

    protected override void ResetValue(){
        this.SetPowerUpgradePoint();
    }

    public virtual void SendPowerUpgradePoint(Transform other){
        BoxPowerReceiver boxPowerReceiver = other.GetComponentInChildren<BoxPowerReceiver>();
        if(boxPowerReceiver == null) return;
        SendPowerUpgradePoint(boxPowerReceiver);
    }

    public virtual void SendPowerUpgradePoint(BoxPowerReceiver boxPowerReceiver){
        boxPowerReceiver.AddPowerUpgradePoint(this.powerUpgradePoint);
    }

    protected abstract void SetPowerUpgradePoint();
}
