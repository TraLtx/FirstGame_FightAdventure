using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinImpact : GameMonoBehaviour
{
    [SerializeField] protected CoinCtrl coinCtrl;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadBoxGunCtrl();
    }

    protected virtual void LoadBoxGunCtrl(){
        if(this.coinCtrl != null) return;

        this.coinCtrl = transform.parent.GetComponent<CoinCtrl>();
    }
    
    protected void OnTriggerEnter2D(Collider2D other){
        if(! (other.tag == "Player")) return;

        this.coinCtrl.CollectThisCoin(other.transform);

        // this.boxGunCtrl.UpgradeGun.GetComponent<UpgradeGun>().Upgrade(other.transform);
        // Destroy(transform.gameObject);
    }
}
