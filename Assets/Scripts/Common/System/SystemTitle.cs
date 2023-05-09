using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemTitle : GameMonoBehaviour
{
    private static SystemTitle instance;
    public static SystemTitle Instance {get => instance;}

    [SerializeField] protected Animator animator;
    [SerializeField] protected Text txtContent;

    [SerializeField] protected string content;

    protected override void Awake(){
        base.Awake();
        if(instance != null) return;
        instance = this;
    }

    protected override void LoadComponents(){
        this.LoadAnimator();
        this.LoadTxtContent();
    }

    protected virtual void LoadAnimator(){
        if(this.animator != null) return;
        this.animator = GetComponent<Animator>();
    }

    protected virtual void LoadTxtContent(){
        if(this.txtContent != null) return;
        this.txtContent = transform.Find("TitleContent").GetComponent<Text>();
    }

    public virtual void ChangeContent(string content){
        this.content = content;
        this.animator.SetTrigger("ChangeTitle");
    }

    public virtual void OnHide(){
        this.txtContent.text = this.content;
    }

}
