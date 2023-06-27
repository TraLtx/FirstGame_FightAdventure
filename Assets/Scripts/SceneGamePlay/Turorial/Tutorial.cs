using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Tutorial : GameMonoBehaviour
{
    [SerializeField] protected Collider2D _collider;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Transform pnlInfor;
    [SerializeField] protected string tutorialContent;
    // [SerializeField] protected int showTime;
    [SerializeField] protected bool isDone;

    protected override void LoadComponents(){
        this.LoadCollider();
        this.LoadAnimator();
        this.LoadPnlInfor();
        this.SetTutorialContent();
        // this.SetShowTime();
        this.isDone = false;
        // transform.GetComponent<SpriteRenderer>().enabled = false;
    }

    protected virtual void LoadCollider(){
        // if(this._collider != null) return;
        this._collider = GetComponent<Collider2D>();
        this._collider.isTrigger = true;
    }

    protected virtual void LoadAnimator(){
        if(this.animator != null) return;
        this.animator = GetComponent<Animator>();
    }

    protected virtual void LoadPnlInfor(){
        if(this.pnlInfor != null) return;
        this.pnlInfor = GameObject.Find("MainCanvas").transform.Find("Pnl_Infor");
    }

    protected virtual void ShowTutorial(){//Debug.Log("ShowTutor");
        this.pnlInfor.gameObject.SetActive(true);
        // this.pnlInfor.GetComponent<InforPanel>().SetActiveTime(this.showTime);
        Debug.Log("Show Tutorial!");
        this.pnlInfor.GetComponent<InforPanel>().ShowPanel(this.tutorialContent);
//
    }

    protected virtual void HideTutorial(){//Debug.Log("ShowTutor");
        // this.pnlInfor.gameObject.SetActive(true);
        // this.pnlInfor.GetComponent<InforPanel>().SetActiveTime(this.showTime);
        this.pnlInfor.GetComponent<InforPanel>().TurnOff();
//
    }

    protected virtual void OnTriggerEnter2D(Collider2D other){
        if(!(other.tag == "Player")) return;
        Debug.Log("Tutorial Hit Player!");
        if(this.isDone == false){
            this.isDone = true;
            animator.SetBool("IsDone", this.isDone);
        }
        this.ShowTutorial();
    }
    protected virtual void OnTriggerExit2D(Collider2D other){
        if(!(other.tag == "Player")) return;

        this.HideTutorial();
    }
    
    // protected virtual void SetShowTime(){
    //     this.showTime = 3;
    // }

    protected abstract void SetTutorialContent();

}
