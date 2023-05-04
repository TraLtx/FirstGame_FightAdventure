using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImpact : GameMonoBehaviour
{
    [Header("Player Impact")]
    [SerializeField] protected BoxCollider2D boxCollider;
    public BoxCollider2D BoxCollider2D {get => this.boxCollider;}
    [SerializeField] protected Rigidbody2D _rigidbody;
    public Rigidbody2D Rigidbody2D {get => this._rigidbody;}

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadCollider(){
        if(this.boxCollider != null) return;

        this.boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void LoadRigidbody(){
        if(this._rigidbody != null) return;

        this._rigidbody = GetComponent<Rigidbody2D>();
        this._rigidbody.gravityScale = 3f;
    }
    
}
