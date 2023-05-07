using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePower : MonoBehaviour
{
    [SerializeField] protected int gunPower = 1;

    public virtual void Upgrade(Transform obj){
        PlayerShooting playeShooting = obj.GetComponentInChildren<PlayerShooting>();
        if(playeShooting == null) return;
        this.Upgrade(playeShooting);
    }

    public virtual void Upgrade(PlayerShooting playeShooting){
        playeShooting.AddShootPower(this.gunPower);
    }
}
