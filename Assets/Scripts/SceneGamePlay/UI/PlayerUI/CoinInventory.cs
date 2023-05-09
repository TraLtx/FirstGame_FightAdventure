using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinInventory : GameMonoBehaviour
{
    [SerializeField] protected Text txtCoin;

    protected override void LoadComponents(){
        this.LoadTxtCoin();
    }

    protected virtual void LoadTxtCoin(){
        if(this.txtCoin != null)  return;
        this.txtCoin = GetComponentInChildren<Text>();
    }

    public virtual void UpdateInventory(int newCoin){
        this.txtCoin.text = newCoin.ToString();
    }
}
