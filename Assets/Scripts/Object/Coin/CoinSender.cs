using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoinSender : GameMonoBehaviour
{
    [SerializeField] protected int coinPoint = 1;

    protected override void ResetValue(){
        this.SetCoinPoint();
    }

    public virtual void SendCoin(Transform other){
        CoinReceiver coinReceiver = other.GetComponentInChildren<CoinReceiver>();
        if(coinReceiver == null) return;
        SendCoin(coinReceiver);
    }

    public virtual void SendCoin(CoinReceiver coinReceiver){
        coinReceiver.AddCoin(this.coinPoint);
    }

    protected abstract void SetCoinPoint();
}
