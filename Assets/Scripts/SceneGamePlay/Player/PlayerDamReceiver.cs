using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamReceiver : DamReceiver//, IHpBarInterface
{
    public override void Deduct(int subNum){
        // Debug.Log(subNum);
        if(subNum <= transform.parent.GetComponent<PlayerCtrl>().GetShieldStatus()) return;
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

    protected override void SetHp(){
        this.maxHp = 10;
        this.hp = maxHp;
    }
}
