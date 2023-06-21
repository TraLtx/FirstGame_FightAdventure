using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGunSilverSender : BoxGunSender
{
    protected override void SetGunUpgradePoint(){
        this.gunUpgradePoint = 10;
    }
}
