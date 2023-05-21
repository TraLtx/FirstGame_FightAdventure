using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ShopItem : GameMonoBehaviour
{
    [SerializeField] protected int levelMax;
    [SerializeField] protected int level;

    [SerializeField] protected List<ItemShopData> itemDataList;
    [SerializeField] protected int cost;

    [SerializeField] protected Text txtCost;
    [SerializeField] protected Text txtBuy;
    [SerializeField] protected Text txtInfor;
    [SerializeField] protected Transform pnlSoldOut;

    protected override void LoadComponents(){
        this.LoadTxtCost();
        this.LoadTxtBuy();
        this.LoadTxtInfor();
        this.LoadPnlSoldOut();
        // this.InitData();
        // this.LoadPlayerData();
    }

    protected abstract void InitData();
    protected abstract void LoadPlayerData();
    public abstract void CheckIsSoldOut();

    protected virtual void LoadTxtCost(){
        if(this.txtCost != null) return;
        this.txtCost = transform.Find("Cost").GetComponent<Text>();
    }

    protected virtual void LoadTxtBuy(){
        if(this.txtBuy != null) return;
        this.txtBuy = transform.Find("Btn_Buy/Label_Buy").GetComponent<Text>();
    }

    protected virtual void LoadTxtInfor(){
        if(this.txtInfor != null) return;
        this.txtInfor = transform.Find("Txt_Infor").GetComponent<Text>();
    }

    protected virtual void LoadPnlSoldOut(){
        if(this.pnlSoldOut != null) return;
        this.pnlSoldOut = transform.Find("Pnl_SoldOut");
    }

    protected virtual void SetTxtCost(string value){
        this.txtCost.text = value;
    }

    protected virtual void SetTxtBuy(string value){
        this.txtBuy.text = value;
    }

    protected virtual void SetTxtInfor(string value){
        this.txtInfor.text = value;
    }

    public virtual void SetNewItemData(){
        this.LoadPlayerData();//Debug.Log("item. level: "+this.level+", max: "+this.levelMax);
        // Now I use this fast way, but it can change by use foreach
        this.cost = itemDataList[this.level].Cost;
        this.SetTxtCost(this.cost.ToString());
        this.SetTxtBuy("BUY");
        this.SetTxtInfor(itemDataList[this.level].Infor);

        this.CheckIsSoldOut();
    }

    public virtual int GetCost(){
        return this.cost;
    }
    
}
