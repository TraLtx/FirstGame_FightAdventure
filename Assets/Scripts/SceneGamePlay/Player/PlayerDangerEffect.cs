using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDangerEffect : GameMonoBehaviour
{
    [SerializeField] protected Animator animator;

    protected override void LoadComponents(){Debug.Log("PlayerDangerEffect.LoadComponents()");
        base.LoadComponents();
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator(){
        if(this.animator != null) return;
        this.animator = GetComponent<Animator>();
    }

    public virtual void NotifyDanger(){
        this.animator.SetTrigger("Dangerous");
    }
}
