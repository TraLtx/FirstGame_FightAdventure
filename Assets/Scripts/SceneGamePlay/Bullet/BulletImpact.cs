using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpact : GameMonoBehaviour
{
    [Header("Bullet Impact")]
    [SerializeField] protected BulletCtrl bulletCtrl;

    //Tam
    [SerializeField] protected Animator animator;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadBulletCtrl();
        this.LoadAnimator();
    }

    protected virtual void LoadBulletCtrl(){
        if(this.bulletCtrl != null) return;

        this.bulletCtrl = GetComponent<BulletCtrl>();
    }

    protected virtual void LoadAnimator(){
        if(this.animator != null) return;

        this.animator = GetComponent<Animator>();
    }
    
    protected virtual void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "NotPhysic" || other.tag == "Bullet" || bulletCtrl.Shooter == other.transform) return;

        bulletCtrl.SetMoveAble(false);
        bulletCtrl.DamSender.Send(other.transform);
        this.PlayAnimation();
    }

    protected virtual void PlayAnimation(){
        if(this.animator == null){
            this.Despawn();
            return;
        }
        
        this.animator.SetBool("IsBoom", true);        
    }

    public virtual void Despawn(){
        bulletCtrl.BulletDespawner.Despawn();
    }
}
