using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCtrl : GameMonoBehaviour
{
    [SerializeField] protected DamSender damSender;
    public DamSender DamSender{get => this.damSender;}

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadDamSender();
    }

    protected virtual void LoadDamSender(){
        if(this.damSender != null) return;

        this.damSender = transform.GetComponentInChildren<DamSender>();
    }
}
