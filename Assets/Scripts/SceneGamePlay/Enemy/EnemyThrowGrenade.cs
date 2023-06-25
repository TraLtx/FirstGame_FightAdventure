using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrowGrenade : ThrowGrenade
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        this.LoadCtrl();
        base.LoadComponents();
    }
    protected virtual void LoadCtrl(){
        if(this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }
    protected override bool GetShootAble()
    {
        if(!enemyCtrl.CanShootPlayer || enemyCtrl.IsDie) return false;

        return true;
    }

    protected override void ControlShootingPoint(){
        this.shootingPoint.eulerAngles = new Vector3(shootingPoint.eulerAngles.x,shootingPoint.eulerAngles.y,enemyCtrl.TargetDistance * 4.5f);
        // Debug.Log("Distance: "+ distance);
    }

    protected override void SetShootingPoint()
    {
        this.shootingPoint = this.enemyCtrl.GetShootingPoint();
    }
}
