using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : GameMonoBehaviour
{
    [SerializeField] protected Animator animator;

    protected override void LoadComponents(){
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator(){
        if(this.animator != null) return;
        this.animator = GetComponent<Animator>();
    }

    public virtual void ChangeScene(){
        animator.SetTrigger("FadeIn");
    }

    public virtual void OnFadeInDone(){
        MainMenuManager.Instance.LoadNextScene();
    }
}
