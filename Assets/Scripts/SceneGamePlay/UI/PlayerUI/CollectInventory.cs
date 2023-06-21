using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectInventory : GameMonoBehaviour
{
    [SerializeField] protected Text colectPoint;

    protected override void LoadComponents(){
        this.LoadTxtCoin();
    }

    protected virtual void LoadTxtCoin(){
        if(this.colectPoint != null)  return;
        this.colectPoint = GetComponentInChildren<Text>();
    }

    public virtual void UpdateInventory(int newCoin){
        this.colectPoint.text = newCoin.ToString();
    }
}
