using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICircleSlider : GameMonoBehaviour
{
    [SerializeField] protected Image fillArea;

    protected override void LoadComponents(){
        this.LoadFillArea();
    }

    protected virtual void LoadFillArea(){
        if(this.fillArea != null) return;
        this.fillArea = transform.Find("CircleFillArea").GetComponent<Image>();
    }

    public virtual void UpdateSlider(float value){
        this.fillArea.fillAmount = value;
    }
}
