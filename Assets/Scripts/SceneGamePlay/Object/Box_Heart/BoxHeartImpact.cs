using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHeartImpact : GameMonoBehaviour
{
    [SerializeField] protected BoxHeartCtrl boxHeartCtrl;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadBoxHeartCtrl();
    }

    protected virtual void LoadBoxHeartCtrl(){
        if(this.boxHeartCtrl != null) return;

        this.boxHeartCtrl = GetComponent<BoxHeartCtrl>();
    }
    
    protected void OnTriggerEnter2D(Collider2D other){
        if(! (other.tag == "Player")) return;

        this.boxHeartCtrl.Healer.GetComponent<Healer>().Heal(other.transform);
        Destroy(transform.gameObject);
    }
}
