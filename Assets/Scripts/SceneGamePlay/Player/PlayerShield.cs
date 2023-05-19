using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShield : Shield
{
    [SerializeField] protected UICircleSlider circleSlider;

    [SerializeField] protected Transform lockSkill;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadIconLock();
        this.LoadSlider();
    }

    protected virtual void LoadIconLock(){
        if(this.lockSkill != null) return;
        this.lockSkill = transform.parent.Find("Canvas/ShieldTimer/Lock");
    }


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
    protected override void SetUseAble(){
        this.useAble = PlayerPrefs.GetInt("Shield") > 0;
    }
    protected override bool GetShieldAble(){
        if(!GameController.Instance.IsOnlineState && this.useAble) return InputManager.Instance.GetShieldStatus();

        // return InputManager.Instance.GetShieldStatus() && playerCtrl.View.IsMine;
        return false;
    }

    protected override void UpdateSlider(){Debug.Log("UpdateSlider");
        float value = this.GetSliderValue();
        this.circleSlider.UpdateSlider(value);
    }

    protected virtual void LoadSlider(){
        if(this.circleSlider != null) return;
        this.circleSlider = transform.parent.Find("Canvas/ShieldTimer").GetComponent<UICircleSlider>();
    }

    protected virtual void Start(){
        if(PlayerPrefs.GetInt("Shield") == 0){
            this.delayTimer = 0;
            this.UpdateSlider();
            this.lockSkill.gameObject.SetActive(true);
            return;
        }
        
    }
}
