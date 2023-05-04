using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAbstract : GameMonoBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl EnemyCtrl {get => this.enemyCtrl;}

    protected override void LoadComponents(){
        // base.LoadComponents();
        this.LoadenEnemyCtrl();
    }

    protected virtual void LoadenEnemyCtrl(){
        if(this.enemyCtrl != null) return;

        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }
}
