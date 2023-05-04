using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : GameMonoBehaviour
{
    [Header("Bullet Impact")]
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl(){
        if(this.bulletCtrl != null) return;

        this.bulletCtrl = GetComponent<BulletCtrl>();
    }
    
    protected void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "NotPhysic" || other.tag == "Bullet" || bulletCtrl.Shooter == other.transform) return;

        bulletCtrl.DamSender.Send(other.transform);
        bulletCtrl.BulletDespawner.Despawn();
    }
}
