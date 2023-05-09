using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeCtrl : GameMonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rigidbody;
    public Rigidbody2D GetRigidbody => this._rigidbody;
    [SerializeField] protected Collider2D _colilder;
    public Collider2D GetCollider => this._colilder;

    protected override void LoadComponents(){
        // base.LoadComponents();
        this.LoadRigidbody();
        this.LoadCollider();
    }

    protected virtual void LoadRigidbody(){
        if(this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void LoadCollider(){
        if(this._colilder != null) return;
        this._colilder = GetComponent<Collider2D>();
    }
}
