using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShield : ShopItem
{
    protected static ItemShield instance;
    public static ItemShield Instance {get => instance;}

    protected override void Awake(){
        base.Awake();

        GameObject newGameObj = new GameObject("ItemData");
        newGameObj.AddComponent<ItemShopData>();

        if(instance != null) return;
        instance = this;
    }

    protected virtual void Start()
    {
        this.InitData();
        this.CheckIsSoldOut();
    }

    protected override void LoadPlayerData(){
        this.level = PlayerPrefs.GetInt(Constant.SAVE_SHIELD_LEVEL);
    }

    protected override void InitData(){
        this.levelMax = 5;

        int startLevel = 1;
        ItemShopData itemData;
        itemData = new ItemShopData(startLevel, 15, "Unlock Shield");
        this.itemDataList.Add(itemData);

        itemData = new ItemShopData(startLevel + 1, 15, "Upgrade to 2/5");
        this.itemDataList.Add(itemData);

        itemData = new ItemShopData(startLevel + 2, 25, "Upgrade 3/5");
        this.itemDataList.Add(itemData);

        itemData = new ItemShopData(startLevel + 3, 35, "Upgrade 4/5");
        this.itemDataList.Add(itemData);

        itemData = new ItemShopData(startLevel + 4, 45, "Upgrade 5/5");
        this.itemDataList.Add(itemData);
    }

    public override void CheckIsSoldOut(){
        this.LoadPlayerData();
        Debug.Log("1. level: "+this.level+", max: "+this.levelMax);
        if(this.level < this.levelMax){Debug.Log("2. level: "+this.level+", max: "+this.levelMax);
            this.SetNewItemData();
            return;
        }

        this.pnlSoldOut.gameObject.SetActive(true);

    }
    
}
