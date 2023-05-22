using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICircleSlider : GameMonoBehaviour
{
    [SerializeField] protected Image fillArea;
    // [SerializeField] protected Transform pnlLock;

    protected override void LoadComponents(){
        this.LoadFillArea();
        // this.LoadLock();
    }

    // protected virtual void Start(){
    //     if(CheckCanUse()) return;

    //     this.pnlLock.gameObject.SetActive(true);
    // }

    protected virtual void LoadFillArea(){
        if(this.fillArea != null) return;
        this.fillArea = transform.Find("CircleFillArea").GetComponent<Image>();
    }
    // protected virtual void LoadLock(){
    //     if(this.pnlLock != null) return;
    //     this.pnlLock = transform.Find("Lock");
    // }

    public virtual void UpdateSlider(float value){
        this.fillArea.fillAmount = value;
    }

    // protected abstract bool CheckCanUse();
}
