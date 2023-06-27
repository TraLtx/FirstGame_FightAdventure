using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLaserImpact : BulletImpact
{
    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected override void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "NotPhysic" || other.tag == "Bullet" || bulletCtrl.Shooter == other.transform) return;
        if(other.tag == "Enemy") bulletCtrl.DamSender.Send(other.transform);
        else{
            bulletCtrl.SetMoveAble(false);
            this.Despawn();
        }

    }
}
