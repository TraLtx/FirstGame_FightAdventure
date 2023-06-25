using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScopeImpact : GameMonoBehaviour
{
    [SerializeField] protected GrenadeCtrl grenadeCtrl;
    [SerializeField] protected bool isActive = false;
    // [SerializeField] protected Collider2D _collider;

    // protected override void LoadComponents()
    // {
    //     base.LoadComponents();
    //     this.LoadCollider();
    // }

    // protected virtual void LoadCollider(){
    //     if(this._collider != null) return;
    //     this._collider = GetComponent<Collider2D>();
    // }
    // void Start()
    // {
    //     // StartCoroutine(this.Countdown());
    //     Physics2D.IgnoreCollision(GameController.Instance.ThisPlayer.GetComponent<Collider2D>(), this.transform.GetComponent<Collider2D>());
    // }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl(){
        if(this.grenadeCtrl != null) return;
        this.grenadeCtrl = transform.parent.GetComponent<GrenadeCtrl>();
    }
    public virtual void ActiveScope(){
        this.isActive = true;
    }
    public virtual void DeactiveScope(){
        this.isActive = false;
    }

    private void OnTriggerStay2D(Collider2D other){//Debug.Log("Hit Something");
        // if(other.tag == "Player"){Debug.Log("Hit Player ==> BOOM");
        //     grenadeCtrl.Boom();
        // }

        if(this.isActive == false || other.CompareTag(grenadeCtrl.ShooterTag)) return;

        Debug.Log("Boom Something");

        grenadeCtrl.DamSender.Send(other.transform);
    }
}
