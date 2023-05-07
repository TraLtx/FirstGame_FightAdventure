using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPowerImpact : GameMonoBehaviour
{
    [SerializeField] protected BoxPowerCtrl boxPowerCtrl;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadBoxGunCtrl();
    }

    protected virtual void LoadBoxGunCtrl(){
        if(this.boxPowerCtrl != null) return;

        this.boxPowerCtrl = GetComponent<BoxPowerCtrl>();
    }
    
    protected void OnTriggerEnter2D(Collider2D other){
        if(! (other.tag == "Player")) return;

        this.boxPowerCtrl.UpgradePower.GetComponent<UpgradePower>().Upgrade(other.transform);
        Destroy(transform.gameObject);
    }
}
