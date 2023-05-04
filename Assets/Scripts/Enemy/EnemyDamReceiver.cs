using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamReceiver : DamReceiver//, IHpBarInterface
{
    protected override void OnDead(){
        Destroy(transform.parent.gameObject);
    }
    protected override void LoadHpBar(){
        if(this.hpBar != null) return;
        this.hpBar = transform.parent.GetComponentInChildren<UIHpBar>();
    }

    // public int HP(){
    //     return (this.hp/this.maxHp)*100;
    // }
}
