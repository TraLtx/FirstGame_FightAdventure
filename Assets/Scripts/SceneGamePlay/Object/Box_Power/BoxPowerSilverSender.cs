using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPowerSilverSender : BoxPowerSender
{
    protected override void SetPowerUpgradePoint(){
        this.powerUpgradePoint = 10;
    }
}
