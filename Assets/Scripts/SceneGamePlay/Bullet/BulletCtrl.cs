using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : GameMonoBehaviour
{
    [Header("Bullet Ctrl")]
    [SerializeField] protected DamSender damSender;
    public DamSender DamSender{get => this.damSender;}

    [SerializeField] protected BulletDespawner bulletDespawner;
    public BulletDespawner BulletDespawner{get => this.bulletDespawner;}

    [SerializeField] protected Transform shooter;
    public Transform Shooter{get => this.shooter;}

    [SerializeField] protected bool isMoveAble;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadDamSender();
        this.LoadBulletDespawner();
    }

    public virtual void ResetBorn(){
        this.isMoveAble = true;
    }

    protected virtual void LoadDamSender(){
        if(this.damSender != null) return;

        this.damSender = transform.GetComponentInChildren<DamSender>();
    }

    protected virtual void LoadBulletDespawner(){
        if(this.bulletDespawner != null) return;

        this.bulletDespawner = transform.GetComponentInChildren<BulletDespawner>();
    }

    public virtual void SetShooter(Transform shooter){
        this.shooter = shooter;
    }

    public virtual void SetDamage(int dam){
        this.damSender.SetDamage(dam);
    }

    public virtual void SetMoveAble(bool value){
        this.isMoveAble = value;
    }
    public virtual bool GetMoveAble(){
        return this.isMoveAble;
    }
}
