using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : GameMonoBehaviour
{
    [SerializeField] protected Collider2D _collider;
    [SerializeField] protected Animator animator;

    protected override void LoadComponents(){
        this.LoadCollider();
        this.LoadAnimator();
    }

    protected virtual void LoadCollider(){
        if(this._collider != null) return;
        this._collider = GetComponent<Collider2D>();
    }

    protected virtual void LoadAnimator(){
        if(this.animator != null) return;
        this.animator = GetComponent<Animator>();
    }

    public virtual void OpenDoor(){
        this.animator.SetBool("ToOpen", true);
    }

    public virtual void DoorOpenDone(){
        this._collider.isTrigger = true;
        this.transform.tag = "NotPhysic";
    }
}
