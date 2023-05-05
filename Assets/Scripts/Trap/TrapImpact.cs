using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapImpact : GameMonoBehaviour
{
    [Header("Trap Impact")]
    [SerializeField] protected TrapCtrl trapCtrl;

    [SerializeField] protected float delaySendDam = 1;
    [SerializeField] protected float timerSendDam = 1;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadTrapCtrl();
    }

    protected virtual void LoadTrapCtrl(){
        if(this.trapCtrl != null) return;

        this.trapCtrl = GetComponent<TrapCtrl>();
    }

    protected virtual void FixedUpdate(){
        if(this.timerSendDam >= this.delaySendDam) return;
        
        this.timerSendDam += Time.fixedDeltaTime;
    }
    
    protected void OnCollisionStay2D(Collision2D other){
        if(!(other.collider.tag == "Player")) return;

        if(this.timerSendDam < this.delaySendDam) return;

        this.timerSendDam = 0;
        trapCtrl.DamSender.Send(other.transform);
    }
}
