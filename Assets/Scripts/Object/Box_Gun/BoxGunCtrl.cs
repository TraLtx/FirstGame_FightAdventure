using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGunCtrl : GameMonoBehaviour
{
   //---Component-------------------------------------------------
    [SerializeField] protected Rigidbody2D _rigidbody;
    public Rigidbody2D _Rigidbody => this._rigidbody;

    [SerializeField] protected Collider2D _collider;
    public Collider2D _Collider => this._collider;

    //---Child--------------------------------------------------
    [SerializeField] protected Transform upgradeGun;
    public Transform UpgradeGun => this.upgradeGun;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadRigidbody();
        this.LoadCollider();
        this.LoadUpgradeGun();
    }

    protected virtual void LoadRigidbody(){
        if(this._rigidbody != null) return;
        this._rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void LoadCollider(){
        if(this._collider != null) return;
        this._collider = GetComponent<Collider2D>();
    }

    protected virtual void LoadUpgradeGun(){
        if(this.upgradeGun != null) return;
        this.upgradeGun = transform.Find("UpgradeGun");
    }
}
