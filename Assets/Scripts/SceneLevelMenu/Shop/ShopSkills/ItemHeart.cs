using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeart : ShopItem
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
        this.levelMax = 1;

        int startLevel = 1;
        ItemShopData itemData;
        itemData = new ItemShopData(startLevel, 50, "Use for 5 HP");
        this.itemDataList.Add(itemData);
    }

    public override void CheckIsSoldOut(){
    }
}
