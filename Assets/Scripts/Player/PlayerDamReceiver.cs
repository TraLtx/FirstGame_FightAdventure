using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamReceiver : DamReceiver//, IHpBarInterface
{
    public override void Deduct(int subNum){
        base.Deduct(subNum);
        // Debug.Log(transform.parent.name);
        transform.parent.GetComponent<PlayerCtrl>().PlayerDangerEffect.NotifyDanger();
    }
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
