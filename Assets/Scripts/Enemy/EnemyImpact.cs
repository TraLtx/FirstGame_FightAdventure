using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyImpact : EnemyAbstract
{
    [SerializeField] protected Collider2D _collider;
    public Collider2D _Collider {get => this._collider;}
    [SerializeField] protected Rigidbody2D _rigidbody;
    public Rigidbody2D _Rigidbody {get => this._rigidbody;}

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected override void LoadenEnemyCtrl(){
        if(this.enemyCtrl != null) return;

        this.enemyCtrl = GetComponent<EnemyCtrl>();
    }

    protected virtual void LoadCollider(){
        if(this._collider != null) return;

        this._collider = GetComponent<Collider2D>();
    }

    protected virtual void LoadRigidbody(){
        if(this._rigidbody != null) return;

        this._rigidbody = GetComponent<Rigidbody2D>();
        this._rigidbody.gravityScale = 3f;
    }

    protected virtual void OnCollisionEnter2D(Collision2D other){
        if(!(other.collider.tag == "Enemy")) return;//Debug.Log("stayCollision");

        this.enemyCtrl.IsTouchEnemy = true;
    }

    // protected virtual void OnCollisionExit2D(Collision2D other){
    //     if(!(other.collider.tag == "Enemy")) return;Debug.Log("exitCollision");

    //     this.enemyCtrl.IsTouchEnemy = false;
    // }
}
