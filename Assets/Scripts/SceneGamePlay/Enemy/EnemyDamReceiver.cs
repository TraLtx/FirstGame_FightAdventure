using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamReceiver : DamReceiver//, IHpBarInterface
{
    protected override void OnDead(){
        // Destroy(transform.parent.gameObject);
        transform.parent.GetComponent<EnemyCtrl>().Die();
    }
    protected override void LoadHpBar(){
        if(this.hpBar != null) return;
        this.hpBar = transform.parent.GetComponentInChildren<UIHpBar>();
    }

    protected override void SetHp(){
        this.maxHp = 4;
        this.hp = maxHp;
    }
}
