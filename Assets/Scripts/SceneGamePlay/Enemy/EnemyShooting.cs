using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : Shooting
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void SetParentCtrl(){
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }
    protected override void SetShootDelayMax(){
        this.shootDelayMax = 0.6f;
        this.shootDelay = this.shootDelayMax;
    }
    protected override void SetDelayUp(){
        this.delayUp = 0.15f;
    }
    protected override void SetShootDelayMin(){
        this.shootDelayMin = 0.1f;
    }
    protected override void SetShootDamMax(){
        this.shootDamMax = 5;
    }
    protected override void SetShootPowerMax(){
        this.shootPowerMax = 5;
    }
    protected override void SetBullet(){
        this.bulletName = BulletSpawner.bulletOne;
    }
    protected override void SetShootingPoint(){
        this.shootingPoint = this.enemyCtrl.GetShootingPoint();
    }
    protected override bool GetShootAble(){
        if(!enemyCtrl.IsSeePlayer || enemyCtrl.IsDie) return false;

        return true;
    }

    protected override void SetUseAble(){
        this.useAble = true;
    }
}
