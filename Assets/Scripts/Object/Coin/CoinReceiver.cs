using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoinReceiver : GameMonoBehaviour
{
    [SerializeField] protected int currentCoin = 0;

    public virtual void AddCoin(int coinPoint){
        this.currentCoin += coinPoint;
        Debug.Log("Coin: "+this.currentCoin);
    }
}
