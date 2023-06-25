using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverCoinSender : CoinSender
{
    protected override void SetCoinPoint(){
        this.coinPoint = 10;
    }
}
