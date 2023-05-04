using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbstract : GameMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl {get => this.playerCtrl;}

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl(){
        if(this.playerCtrl != null) return;

        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
    }
}
