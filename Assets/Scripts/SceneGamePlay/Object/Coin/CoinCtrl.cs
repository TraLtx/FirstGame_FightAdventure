using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCtrl : GameMonoBehaviour
{
    //---Component-------------------------------------------------
    // [SerializeField] protected Rigidbody2D _rigidbody;
    // public Rigidbody2D _Rigidbody => this._rigidbody;

    [SerializeField] protected Collider2D _collider;
    public Collider2D _Collider => this._collider;


    //---Child--------------------------------------------------
    [SerializeField] protected CoinSender coinSender;
    public CoinSender CoinSender => this.coinSender;

    protected override void LoadComponents(){
        base.LoadComponents();
        // this.LoadRigidbody();
        this.LoadCollider();
        this.LoadCoinSender();
    }

    // protected virtual void LoadRigidbody(){
    //     if(this._rigidbody != null) return;
    //     this._rigidbody = GetComponent<Rigidbody2D>();
    // }

    protected virtual void LoadCollider(){
        if(this._collider != null) return;
        this._collider = GetComponentInChildren<Collider2D>();
        this._collider.isTrigger = true;
    }

    protected virtual void LoadCoinSender(){
        if(this.coinSender != null) return;
        this.coinSender = transform.GetComponentInChildren<CoinSender>();
    }

    public virtual void CollectThisCoin(Transform other){
        this.coinSender.SendCoin(other);
        this.BackToPool();
    }

    protected virtual void BackToPool(){
        CoinSpawner.Instance.BackObjToPool(transform);
    }
}
