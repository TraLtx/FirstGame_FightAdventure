using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : GameMonoBehaviour
{
    [SerializeField] protected int hp = 1;

    public virtual void Heal(Transform obj){
        DamReceiver damReceiver = obj.GetComponentInChildren<DamReceiver>();
        if(damReceiver == null) return;
        this.Heal(damReceiver);
    }

    public virtual void Heal(DamReceiver damReceiver){
        damReceiver.AddHp(this.hp);
    }
}
