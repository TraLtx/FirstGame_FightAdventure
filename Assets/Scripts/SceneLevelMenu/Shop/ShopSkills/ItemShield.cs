using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShield : ShopItem
{
    protected static ItemShield instance;
    public static ItemShield Instance {get => instance;}

    protected override void Awake(){
        base.Awake();

        if(instance != null) return;
        instance = this;
    }

    protected virtual void Start()
    {
        this.InitData();
        this.SetNewItemData();
    }

    protected override void LoadPlayerData(){
        this.level = PlayerPrefs.GetInt(Constant.SAVE_SHIELD_LEVEL);
        Debug.Log("Shiled_Level_Save: " + this.level);
    }

    protected override void InitData(){
        this.levelMax = 5;

        int startLevel = 1;

        GameObject dataholder = new GameObject("LevelDataHolder");
        dataholder.transform.SetParent(gameObject.transform);

        GameObject itemLevel_1 = new GameObject("ItemLevel_1");
        itemLevel_1.transform.SetParent(dataholder.transform);
        ItemShopData itemData = itemLevel_1.AddComponent<ItemShopData>();
        itemData.CreateItemShopData(startLevel, 15, "Unlock Shield");
        this.itemDataList.Add(itemData);

        GameObject itemLevel_2 = new GameObject("ItemLevel_2");
        itemLevel_2.transform.SetParent(dataholder.transform);
        itemData = itemLevel_2.AddComponent<ItemShopData>();
        itemData.CreateItemShopData(startLevel + 1, 15, "Upgrade to 2/5");
        this.itemDataList.Add(itemData);

        GameObject itemLevel_3 = new GameObject("ItemLevel_3");
        itemLevel_3.transform.SetParent(dataholder.transform);
        itemData = itemLevel_3.AddComponent<ItemShopData>();
        itemData.CreateItemShopData(startLevel + 2, 25, "Upgrade to 3/5");
        this.itemDataList.Add(itemData);

        GameObject itemLevel_4 = new GameObject("ItemLevel_4");
        itemLevel_4.transform.SetParent(dataholder.transform);
        itemData = itemLevel_4.AddComponent<ItemShopData>();
        itemData.CreateItemShopData(startLevel + 3, 35, "Upgrade to 4/5");
        this.itemDataList.Add(itemData);

        GameObject itemLevel_5 = new GameObject("ItemLevel_5");
        itemLevel_5.transform.SetParent(dataholder.transform);
        itemData = itemLevel_5.AddComponent<ItemShopData>();
        itemData.CreateItemShopData(startLevel + 4, 45, "Upgrade to 5/5");
        this.itemDataList.Add(itemData);

        GameObject itemLevel_6 = new GameObject("ItemLevel_6");
        itemLevel_6.transform.SetParent(dataholder.transform);
        itemData = itemLevel_5.AddComponent<ItemShopData>();
        itemData.CreateItemShopData(startLevel + 4, 0, "Max level");
        this.itemDataList.Add(itemData);
    }

    public override void CheckIsSoldOut(){
        //this.LoadPlayerData();
        //Debug.Log("shiled. level: "+this.level+", max: "+this.levelMax);
        if(this.level < this.levelMax){
            return;
        }

        this.pnlSoldOut.gameObject.SetActive(true);

    }
    
}
