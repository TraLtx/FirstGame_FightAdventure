using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : GameMonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected GameController gameCtrl;

    protected override void LoadComponents(){
        this.LoadAnimator();
    }

    protected virtual void Start(){
        this.gameCtrl = GameController.Instance;
    }

    protected virtual void LoadAnimator(){
        if(this.animator != null) return;
        this.animator = transform.GetComponent<Animator>();
    }

    public virtual void Show(){
        this.animator.SetBool("IsShow", true);
    }

    public virtual void Hide(){
        this.animator.SetBool("IsShow", false);
    }
}
