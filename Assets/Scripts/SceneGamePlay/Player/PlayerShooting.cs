using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : Shooting
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected UIDamBar damBar;
    [SerializeField] protected UIPowerBar powerBar;

    [SerializeField] protected AudioSource _audioSource;

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

    protected override void LoadComponents(){Debug.Log("PlayerShooting.LoadComponents()");
        base.LoadComponents();
        this.LoadDamBar();
        this.LoadPowerBar();
        this.LoadAudioSource();
    }

    protected virtual void LoadDamBar(){
        if(this.damBar != null) return;
        this.damBar = transform.parent.GetComponentInChildren<UIDamBar>();
    }

    protected virtual void LoadPowerBar(){
        if(this.powerBar != null) return;
        this.powerBar = transform.parent.GetComponentInChildren<UIPowerBar>();
    }
    protected virtual void LoadAudioSource(){
        if(this._audioSource != null) return;
        this._audioSource = GetComponent<AudioSource>();
    }

    protected virtual void Start(){
        this.LoadPlayerDataGun();
        this.LoadPlayerDataPower();
        this.damBar.UpdateBar(this.shootDam);
        this.powerBar.UpdateBar(this.shootPower);
        
        this.shootDelay = 1f - this.shootPower * 0.15f;
    }

    protected override void Shoot(){
        base.Shoot();
        this.PlaySFX();
    }

    protected virtual void LoadPlayerDataGun(){
        this.shootDam = PlayerPrefs.GetInt(Constant.SAVE_GUN_LEVEL);
        if(this.shootDam < 1) this.shootDam = 1;
    }

    protected virtual void LoadPlayerDataPower(){
        this.shootPower = PlayerPrefs.GetInt(Constant.SAVE_POWER_LEVEL);
        if(this.shootPower < 1) this.shootPower = 1;
    }

    public override void AddShootDam(int dam){
        base.AddShootDam(dam);

        this.damBar.UpdateBar(this.shootDam);
    }

    public override void AddShootPower(int power){
        base.AddShootPower(power);

        this.powerBar.UpdateBar(this.shootPower);
    }

    protected override void SetUseAble(){
        this.useAble = true;
    }

    protected virtual void PlaySFX(){Debug.Log("Tach*SFX");
        this._audioSource.Play();
    }
}
