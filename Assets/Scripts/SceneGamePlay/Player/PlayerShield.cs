using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : Shield
{
    [SerializeField] protected UICircleSlider circleSlider;

    protected override void SetShieldPoint(){
        this.shieldPoint = 1;
    }
    protected override void SetShieldTime(){
        this.shieldTime = 2f;
    }
    protected override void SetShieldStartStatus(){
        this.shieldStatus = 0;
    }
    protected override void SetDelayTime(){
        this.delayTime = 30f;
        this.delayTimer = this.delayTime;
        this.UpdateSlider();
    }
    protected override bool GetShieldAble(){
        if(!GameController.Instance.IsOnlineState) return InputManager.Instance.GetShieldStatus();

        // return InputManager.Instance.GetShieldStatus() && playerCtrl.View.IsMine;
        return false;
    }

    protected override void UpdateSlider(){Debug.Log("UpdateSlider");
        float value = this.GetSliderValue();
        this.circleSlider.UpdateSlider(value);
    }

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadSlider();
    }

    protected virtual void LoadSlider(){
        if(this.circleSlider != null) return;
        this.circleSlider = transform.parent.Find("Canvas/ShieldTimer").GetComponent<UICircleSlider>();
    }
}
