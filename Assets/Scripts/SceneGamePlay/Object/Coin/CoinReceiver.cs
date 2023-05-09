using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoinReceiver : GameMonoBehaviour
{
    [SerializeField] protected int currentCoin = 0;
    [SerializeField] protected CoinInventory coinInventory;

    protected override void LoadComponents(){
        this.coinInventory = transform.parent.GetComponentInChildren<CoinInventory>();
    }

    public virtual void AddCoin(int coinPoint){
        this.currentCoin += coinPoint;
        this.coinInventory.UpdateInventory(this.currentCoin);
    }
}
