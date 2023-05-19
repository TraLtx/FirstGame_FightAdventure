using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shield : GameMonoBehaviour
{
    [SerializeField] protected Animator animator;

    [SerializeField] protected int shieldPoint;
    [SerializeField] protected float shieldTime;
    [SerializeField] protected float shiledTimer;
    [SerializeField] protected int shieldStatus;

    [SerializeField] protected float delayTime;
    [SerializeField] protected float delayTimer;

    [SerializeField] protected bool useAble;

    protected override void LoadComponents(){
        this.LoadAnimator();
    }
    protected virtual void LoadAnimator(){
        if(this.animator != null) return;
        this.animator = GetComponent<Animator>();
    }

    protected override void ResetValue(){
        this.SetShieldPoint();
        this.SetShieldTime();
        this.SetShieldStartStatus();
        this.SetDelayTime();
        this.SetUseAble();
    }
    protected abstract void SetShieldPoint();
    protected abstract void SetShieldTime();
    protected abstract void SetShieldStartStatus();
    protected abstract void SetDelayTime();
    protected abstract void SetUseAble();
    protected abstract bool GetShieldAble();

    protected virtual void FixedUpdate(){

        if(!this.useAble) return;

        if(this.GetShieldAble() && this.delayTimer >= this.delayTime){//Khi khong co khien thi khong can dem nguoc delay
            this.TurnOnShield();
            return; 
        }

        if(this.shieldStatus == 0 && this.delayTimer >= this.delayTime) return;

        if(this.delayTimer < this.delayTime){
            this.delayTimer += Time.fixedDeltaTime;
            this.UpdateSlider();
        }

        if(this.shieldStatus == 0) return;
        if(this.shiledTimer < this.shieldTime){
            this.shiledTimer += Time.fixedDeltaTime;
        }else{
            this.shiledTimer = this.shieldTime;
            this.TurnOffShield();
        }
    }

    protected virtual void UpdateSlider(){
        //Override
    }

    protected virtual float GetSliderValue(){
        float value = 1 - (this.delayTimer/this.delayTime);
        if(value > 0) return value;
        return 0;
    }

    public virtual void TurnOnShield(){
        this.shieldStatus = this.shieldPoint;
        this.animator.SetBool("IsTurnOn", true);
        this.shiledTimer = 0f;
        this.delayTimer = 0f;
    }

    public virtual void TurnOffShield(){
        this.shieldStatus = 0;
        this.animator.SetBool("IsTurnOn", false);
    }

    public virtual int GetShieldStatus(){
        return this.shieldStatus;
    }
}
