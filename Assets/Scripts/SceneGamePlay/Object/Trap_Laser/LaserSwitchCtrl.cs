using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitchCtrl : GameMonoBehaviour
{
    [SerializeField] TrapLaserCtrl trapCtrl;
    [SerializeField] Animator _animator;

    [SerializeField] protected int status = 1;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrapCtrl();
        this.LoadAnimator();
    }
    protected virtual void LoadTrapCtrl(){
        if(this.trapCtrl != null) return;
        this.trapCtrl = transform.parent.GetComponent<TrapLaserCtrl>();
    }
    protected virtual void LoadAnimator(){
        if(this._animator != null) return;
        this._animator = transform.GetComponent<Animator>();
    }

    protected virtual void TurnOn(){
        this.status = 1;
        this._animator.SetBool("IsTurnOn", true);
        this.trapCtrl.TurnOnLaser();
    }

    protected virtual void TurnOff(){
        this.status = 0;
        this._animator.SetBool("IsTurnOn", false);
        this.trapCtrl.TurnOffLaser();
    }

    public virtual void SwitchAttack(){
        if(this.status == 0) this.TurnOn();
        else if(this.status == 1) this.TurnOff();
    }
}
