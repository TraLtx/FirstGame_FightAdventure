using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHeartCtrl : GameMonoBehaviour
{
    //---Component-------------------------------------------------
    [SerializeField] protected Rigidbody2D _rigidbody;
    public Rigidbody2D _Rigidbody => this._rigidbody;

    [SerializeField] protected Collider2D _collider;
    public Collider2D _Collider => this._collider;

    //---Child--------------------------------------------------
    [SerializeField] protected Transform healer;
    public Transform Healer => this.healer;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadRigidbody();
        this.LoadCollider();
        this.LoadHealer();
    }

    protected virtual void LoadRigidbody(){
        if(this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void LoadCollider(){
        if(this._collider != null) return;
        this._collider = GetComponent<Collider2D>();
    }

    protected virtual void LoadHealer(){
        if(this.healer != null) return;
        this.healer = transform.Find("Healer");
    }
}
