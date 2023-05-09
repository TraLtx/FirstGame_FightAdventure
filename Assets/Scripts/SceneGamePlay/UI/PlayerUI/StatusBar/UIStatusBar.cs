using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatusBar : GameMonoBehaviour
{
    // [SerializeField] private Transform hpBarData;
    [SerializeField] private Slider slider;

    protected override void LoadComponents(){
        this.LoadSlider();
    }

    protected virtual void LoadSlider(){
        if(this.slider != null) return;
        this.slider = GetComponent<Slider>();
    }

    public virtual void UpdateBar(int value){//Debug.Log("UpdateBar");
        if(this.slider == null) return;

        // IHpBarInterface hpBarInterface = this.hpBarData.GetComponent<IHpBarInterface>();
        this.slider.value = value;//hpBarInterface.HP(); Debug.Log("HP: "+hpBarInterface.HP());
    }
}
