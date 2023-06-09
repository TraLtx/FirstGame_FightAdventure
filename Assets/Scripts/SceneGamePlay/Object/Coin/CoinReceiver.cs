using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoinReceiver : GameMonoBehaviour
{
    [SerializeField] protected int currentCoin = 0;
    [SerializeField] protected CoinInventory collectInventory;

    protected override void LoadComponents(){
        this.collectInventory = transform.parent.GetComponentInChildren<CoinInventory>();
    }

    public virtual void AddCoin(int coinPoint){
        this.currentCoin += coinPoint;
        this.collectInventory.UpdateInventory(this.currentCoin);
    }

    public virtual int GetCoinCollect(){
        return this.currentCoin;
    }
}
