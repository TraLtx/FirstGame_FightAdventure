using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLaserCtrl : GameMonoBehaviour
{
    [SerializeField] protected LaserGun laserGun;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLaserGun();
    }
    protected virtual void LoadLaserGun(){
        if(this.laserGun != null) return;
        this.laserGun = transform.GetComponentInChildren<LaserGun>();
    }

    //---PUBLIC---
    public virtual void TurnOnLaser(){
        this.laserGun.Fire();
    }

    public virtual void TurnOffLaser(){
        this.laserGun.Stop();
    }
}
