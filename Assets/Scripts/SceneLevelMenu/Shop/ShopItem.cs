using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : GameMonoBehaviour
{
    [SerializeField] protected Text txtCost;
    [SerializeField] protected Text txtBuy;

    protected override void LoadComponents(){
        this.LoadTxtCost();
        this.LoadTxtBuy();
    }

    protected virtual void LoadTxtCost(){
        if(this.txtCost != null) return;
        this.txtCost = transform.Find("Cost").GetComponent<Text>();
    }

    protected virtual void LoadTxtBuy(){
        if(this.txtBuy != null) return;
        this.txtBuy = transform.Find("Btn_Buy/Label_Buy").GetComponent<Text>();
    }

    public virtual void SetTxtCost(string value){
        this.txtCost.text = value;
    }

    public virtual void SetTxtBuy(string value){
        this.txtBuy.text = value;
    }
}
