using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitchImpact : GameMonoBehaviour
{
    [SerializeField] protected LaserSwitchCtrl switchCtrl;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadBoxGunCtrl();
    }

    protected virtual void LoadBoxGunCtrl(){
        if(this.switchCtrl != null) return;

        this.switchCtrl = transform.GetComponent<LaserSwitchCtrl>();
    }
    
    protected virtual void OnCollisionEnter2D(Collision2D other){
        if(!(other.collider.tag == "Player")) return;

        Debug.Log("Switch Hit Player!!!!");
        switchCtrl.SwitchAttack();
    }

}
