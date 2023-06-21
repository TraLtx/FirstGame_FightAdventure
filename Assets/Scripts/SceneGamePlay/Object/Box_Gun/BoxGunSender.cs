using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoxGunSender : GameMonoBehaviour
{
    [SerializeField] protected int gunUpgradePoint = 1;

    protected override void ResetValue(){
        this.SetGunUpgradePoint();
    }

    public virtual void SendGunUpgradePoint(Transform other){
        BoxGunReceiver boxGunReceiver = other.GetComponentInChildren<BoxGunReceiver>();
        if(boxGunReceiver == null) return;
        SendGunUpgradePoint(boxGunReceiver);
    }

    public virtual void SendGunUpgradePoint(BoxGunReceiver boxGunReceiver){
        boxGunReceiver.AddGunUpgradePoint(this.gunUpgradePoint);
    }

    protected abstract void SetGunUpgradePoint();

}
