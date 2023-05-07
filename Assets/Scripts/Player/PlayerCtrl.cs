using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerCtrl : GameMonoBehaviour
{
    //---Component-------------------------------------------------
    [SerializeField] protected SpriteRenderer spriteRenderer;
    public SpriteRenderer SpriteRenderer => this.spriteRenderer;

    [SerializeField] protected Rigidbody2D _rigidbody;
    public Rigidbody2D _Rigidbody => this._rigidbody;

    [SerializeField] protected Collider2D _collider;
    public Collider2D _Collider => this._collider;

    [SerializeField] protected PhotonView view;
    public PhotonView View => this.view;

    //---Child--------------------------------------------------
    [SerializeField] protected Transform groundCheck;
    public Transform GroundCheck => this.groundCheck;

    [SerializeField] protected Transform shootingPoint;
    public Transform ShootingPoint => this.shootingPoint;

    [SerializeField] protected PlayerDangerEffect playerDangerEffect;
    public PlayerDangerEffect PlayerDangerEffect => this.playerDangerEffect;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadSpriteRenderer();
        this.LoadRigidbody();
        this.LoadCollider();
        this.LoadPhotonView();
        this.LoadGroundCheck();
        this.LoadShootingPoint();
        this.LoadPlayerDangerEffect();
    }

    protected virtual void LoadSpriteRenderer(){
        if(this.spriteRenderer != null) return;
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void LoadRigidbody(){
        if(this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void LoadCollider(){
        if(this._collider != null) return;
        this._collider = GetComponent<Collider2D>();
    }

    protected virtual void LoadPhotonView(){
        if(this.view != null) return;

        this.view = GetComponent<PhotonView>();
    }
    
    protected virtual void LoadShootingPoint(){
        if(this.shootingPoint != null) return;
        this.shootingPoint = transform.Find("ShootingPoint");
    }

    protected virtual void LoadGroundCheck(){
        if(this.groundCheck != null) return;
        this.groundCheck = transform.Find("GroundCheck");
    }

    protected virtual void LoadPlayerDangerEffect(){
        if(this.playerDangerEffect != null) return;
        this.playerDangerEffect = transform.GetComponentInChildren<PlayerDangerEffect>();
    }

    //-----------------------------------------
    protected virtual void Update(){
    }
    //----------------------------------------
    // public virtual void OnDanger(){

    // }

}