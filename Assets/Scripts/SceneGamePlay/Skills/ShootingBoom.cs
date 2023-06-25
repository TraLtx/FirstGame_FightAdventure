using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBoom : Shooting
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected UICircleSlider circleSlider;

    [SerializeField] protected Transform lockSkill;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadIconLockSkill();
        this.LoadSlider();
    }

    protected virtual void LoadIconLockSkill(){
        if(this.lockSkill != null) return;
        this.lockSkill = transform.parent.Find("Canvas/UltiTimer/Lock");
    }

    protected override void SetParentCtrl(){
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
    }
    protected override void SetShootDelayMax(){
        this.shootDelayMax = 30f;
        this.shootDelay = this.shootDelayMax;
        this.shootTimer = this.shootDelay;
    }
    protected override void SetDelayUp(){
        this.delayUp = 5f;
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
        this.bulletName = BulletSpawner.bulletTwo;
    }
    protected override void SetShootingPoint(){
        this.shootingPoint = this.playerCtrl.GetShootingPoint();
    }
    protected override void SetUseAble(){
        this.useAble = PlayerPrefs.GetInt(Constant.SAVE_ULTI_2_LEVEL) > 0;
        Debug.Log("Ulti Save: "+PlayerPrefs.GetInt(Constant.SAVE_ULTI_2_LEVEL));
        Debug.Log("useAble: "+this.useAble);
    }
    protected override bool GetShootAble(){
        if(!this.useAble) return false;

        if(!GameController.Instance.IsOnlineState) return InputManager.Instance.GetUltiStatus();

        return InputManager.Instance.GetUltiStatus() && playerCtrl.View.IsMine;
    }

    protected override void UpdateSlider(){
        float value = this.GetSliderValue();
        this.circleSlider.UpdateSlider(value);//Debug.Log("timer:"+value);
    }


    protected virtual void LoadSlider(){
        if(this.circleSlider != null) return;
        this.circleSlider = transform.parent.Find("Canvas/UltiTimer").GetComponent<UICircleSlider>();
    }

    protected virtual void Start(){this.shootDam = 5;
        if(!this.useAble){
            this.shootTimer = 0;
            this.lockSkill.gameObject.SetActive(true);
            return;
        }this.lockSkill.gameObject.SetActive(false);

        this.UpdateSlider();

        this.LoadPlayerDataUlti_2();
        this.shootDelay = this.shootDelayMax - this.shootPower * this.delayUp;

        // this.damBar.UpdateBar(this.shootDam);
        // this.powerBar.UpdateBar(this.shootPower);
        // this.shootDelay = 1f - this.shootPower * 0.15f;
    }

    protected virtual void LoadPlayerDataUlti_2(){
        this.shootDam = PlayerPrefs.GetInt(Constant.SAVE_ULTI_2_LEVEL);
        this.shootPower = this.shootDam;
    }



    // public virtual void SetDam(){
    //     //
    // }
}
