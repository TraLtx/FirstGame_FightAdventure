using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamReceiver : GameMonoBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected int maxHp;
    [SerializeField] protected int hp;
    [SerializeField] protected bool isDead = false;
    [SerializeField] protected UIHpBar hpBar;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadHpBar();
    }

    protected override void ResetValue(){
        this.SetHp();
    }

    protected virtual void UpdateHpBar(){
        hpBar.UpdateBar(this.hp*100/this.maxHp);
    }

    public virtual void AddHp(int addNum){//Debug.Log("Add");

        if(this.isDead) return;

        this.hp += addNum;

        if(this.hp > this.maxHp) this.hp = this.maxHp;

        this.UpdateHpBar();
    }

    public virtual void Deduct(int subNum){//Debug.Log("Deduct");

        if(this.isDead) return;

        this.hp -= subNum;

        if(this.hp <= 0) 
        {
            this.hp = 0;
        }
        
        this.UpdateHpBar();

        if(this.hp == 0){
            isDead = true;
            this.OnDead();
        }
    }

    protected abstract void OnDead();
    protected abstract void LoadHpBar();
    protected abstract void SetHp();

    // protected virtual bool CheckIsDead(){
    //     if(this.hp == 0) return true;
    //     return false;
    // }
}
