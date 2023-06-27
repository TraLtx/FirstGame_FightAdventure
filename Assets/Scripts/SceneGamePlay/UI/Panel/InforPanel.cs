using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InforPanel : GameMonoBehaviour
{
    // [SerializeField] protected float activeTime = 0;
    // [SerializeField] protected float timer = 0;
    [SerializeField] protected Text txtInfor;
    // [SerializeField] protected bool canTimer = false;

    protected override void LoadComponents(){
        this.LoadTextInfor();
        this.Deactive();
    }

    protected virtual void LoadTextInfor(){
        if(this.txtInfor != null) return;
        this.txtInfor = transform.GetComponentInChildren<Text>();
    }

    protected virtual void Deactive(){
        gameObject.SetActive(false);
    }

    // protected virtual void FixedUpdate(){
    //     if(!this.canTimer) return;

    //     if(this.timer >= this.activeTime){
    //         this.timer = 0;
    //         this.activeTime = 0;
    //         this.canTimer = false;
    //         this.TurnOff();
    //     }else{
    //         this.timer += Time.deltaTime;
    //     }
    // }

    // public virtual void SetActiveTime(int activeTime){
    //     this.activeTime = activeTime;
    //     this.timer = 0;
    // }

    public virtual void ShowPanel(string infor){Debug.Log("ShowPanel()");
        this.txtInfor.text = infor;
        // gameObject.SetActive(true); no here
        // this.StartTimer();
    }

    // public virtual void StartTimer(){
    //     this.canTimer = true;
    // }

    public virtual void TurnOff(){
        this.txtInfor.text = "";
        gameObject.SetActive(false);
        // this.activeTime = 0;
    }
}
