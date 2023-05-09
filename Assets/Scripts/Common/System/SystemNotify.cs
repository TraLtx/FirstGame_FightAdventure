using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemNotify : GameMonoBehaviour
{
    private static SystemNotify instance;
    public static SystemNotify Instance {get => instance;}

    [SerializeField] protected Animator animator;
    [SerializeField] protected Text txtNotify;

    protected override void Awake(){
        base.Awake();
        if(instance != null) return;
        instance = this;
    }

    protected override void LoadComponents(){
        this.LoadAnimator();
        this.LoadTxtNotify();
    }

    protected virtual void LoadAnimator(){
        if(this.animator != null) return;
        this.animator = GetComponent<Animator>();
    }

    protected virtual void LoadTxtNotify(){
        if(this.txtNotify != null) return;
        this.txtNotify = transform.Find("Canvas/Panel/Txt_Notify").GetComponent<Text>();
    }

    public virtual void ShowNotify(string notify){
        this.txtNotify.text = notify;
        this.animator.SetBool("IsShow", true);
        Invoke("HideNotify", 3);
    }

    protected virtual void HideNotify(){
        // this.txtNotify.text = "";
        this.animator.SetBool("IsShow", false);
    }
}
