using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamSender : GameMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj){Debug.Log("SendDam_1 of DamSender - Transform: "+obj.name);
        DamReceiver damReceiver = obj.GetComponentInChildren<DamReceiver>();
        if(damReceiver == null) return;
        this.Send(damReceiver);
    }

    public virtual void Send(DamReceiver damReceiver){Debug.Log("SendDam_2 of DamSender");
        damReceiver.Deduct(this.damage);
    }

    public virtual void SetDamage(int damage){
        this.damage = damage;
    }
}
