using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamReceiver : DamReceiver//, IHpBarInterface
{
    protected override void OnDead(){
        Destroy(transform.parent.gameObject);
        GameController.Instance.ShowDieMenu();
    }

    protected override void LoadHpBar(){
        if(this.hpBar != null) return;
        this.hpBar = transform.parent.GetComponentInChildren<UIHpBar>();
    }

    // public int HP(){
    //     return (this.hp/this.maxHp)*100;
    // }
}
