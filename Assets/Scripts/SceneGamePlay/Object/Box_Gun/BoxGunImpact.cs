using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGunImpact : GameMonoBehaviour
{
    [SerializeField] protected BoxGunCtrl boxGunCtrl;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadBoxGunCtrl();
    }

    protected virtual void LoadBoxGunCtrl(){
        if(this.boxGunCtrl != null) return;

        this.boxGunCtrl = GetComponent<BoxGunCtrl>();
    }
    
    protected void OnTriggerEnter2D(Collider2D other){
        if(! (other.tag == "Player")) return;

        this.boxGunCtrl.UpgradeGun.GetComponent<UpgradeGun>().Upgrade(other.transform);
        Destroy(transform.gameObject);
    }
}
