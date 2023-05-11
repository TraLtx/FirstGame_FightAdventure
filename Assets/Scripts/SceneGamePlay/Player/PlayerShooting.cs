using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : Shooting
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected UIDamBar damBar;
    [SerializeField] protected UIPowerBar powerBar;

    protected override void SetParentCtrl(){
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
    }
    protected override void SetShootDelayMax(){
        this.shootDelayMax = 1f;
        this.shootDelay = this.shootDelayMax;
        this.shootTimer = this.shootDelay;
    }
    protected override void SetDelayUp(){
        this.delayUp = 0.15f;
    }
    protected override void SetShootDelayMin(){
        this.shootDelayMin = 0.1f;
    }
    protected override void SetShootDamMax(){
        this.shootDamMax = 5;
    }
    protected override void SetShootPowerMax(){
        this.shootPowerMax = 5;
    }
    protected override void SetBullet(){
        this.bulletName = BulletSpawner.bulletOne;
    }
    protected override void SetShootingPoint(){
        this.shootingPoint = this.playerCtrl.GetShootingPoint();
    }
    protected override bool GetShootAble(){
        if(!GameController.Instance.IsOnlineState) return InputManager.Instance.GetFightStatus();

        return InputManager.Instance.GetFightStatus() && playerCtrl.View.IsMine;
    }

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadDamBar();
        this.LoadPowerBar();
    }

    protected virtual void LoadDamBar(){
        if(this.damBar != null) return;
        this.damBar = transform.parent.GetComponentInChildren<UIDamBar>();
    }

    protected virtual void LoadPowerBar(){
        if(this.powerBar != null) return;
        this.powerBar = transform.parent.GetComponentInChildren<UIPowerBar>();
    }

    protected virtual void Start(){
        this.damBar.UpdateBar(this.shootDam);
        this.powerBar.UpdateBar(this.shootPower);
        this.shootDelay = 1f - this.shootPower * 0.15f;
    }

    public override void AddShootDam(int dam){
        base.AddShootDam(dam);

        this.damBar.UpdateBar(this.shootDam);
    }

    public override void AddShootPower(int power){
        base.AddShootPower(power);

        this.powerBar.UpdateBar(this.shootPower);
    }

    
}
