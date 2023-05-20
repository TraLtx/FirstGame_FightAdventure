using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUlti : ShopItem
{
    protected virtual void Start()
    {
        this.InitData();
        
        // Now I use this fast way, but it can change by use foreach
        this.SetTxtCost(itemDataList[this.level].Cost.ToString());
        this.SetTxtBuy("BUY");
    }

    protected override void LoadPlayerData(){
        this.level = PlayerPrefs.GetInt(Constant.SAVE_SHIELD_LEVEL);
    }

    protected override void InitData(){
        this.levelMax = 5;

        int startLevel = 1;
        ItemShopData itemData;
        itemData = new ItemShopData(startLevel, 25, "Unlock Ulti");
        this.itemDataList.Add(itemData);

        itemData = new ItemShopData(startLevel + 1, 35, "Upgrade to 2/5");
        this.itemDataList.Add(itemData);

        itemData = new ItemShopData(startLevel + 2, 45, "Upgrade 3/5");
        this.itemDataList.Add(itemData);

        itemData = new ItemShopData(startLevel + 3, 55, "Upgrade 4/5");
        this.itemDataList.Add(itemData);

        itemData = new ItemShopData(startLevel + 4, 65, "Upgrade 5/5");
        this.itemDataList.Add(itemData);
    }

    public override void CheckIsSoldOut(){
        this.LoadPlayerData();
        if(this.level < this.levelMax) return;

        this.pnlSoldOut.gameObject.SetActive(true);

    }
}
