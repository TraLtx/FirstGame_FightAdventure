using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeart : ShopItem
{
    protected static ItemHeart instance;
    public static ItemHeart Instance {get => instance;}

    protected override void Awake(){
        base.Awake();

        if(instance != null) return;
        instance = this;
    }

    // protected virtual void Start()
    // {
    //     this.InitData();
    //     this.SetNewItemData();
        
    //     // // Now I use this fast way, but it can change by use foreach
    //     // this.SetTxtCost(itemDataList[this.level].Cost.ToString());
    //     // this.SetTxtBuy("BUY");
    // }

    protected override void LoadPlayerData(){
        this.level = PlayerPrefs.GetInt(Constant.SAVE_HEART_ITEMS);
        Debug.Log("Heart_save: " + this.level);
    }

    protected override void InitData(){

        this.itemDataList.Clear();
        
        if(transform.Find("LevelDataHolder") != null){
            Debug.Log("Exist Data!");
            Transform levelDataholder = transform.Find("LevelDataHolder");
            foreach (Transform data in levelDataholder)
            {
                this.itemDataList.Add(data.GetComponent<ItemShopData>());
            }
            return;
        }

        this.levelMax = 1;

        int startLevel = 1;

        GameObject dataholder = new GameObject("LevelDataHolder");
        dataholder.transform.SetParent(gameObject.transform);

        GameObject itemLevel_1 = new GameObject("ItemLevel_1");
        itemLevel_1.transform.SetParent(dataholder.transform);
        ItemShopData itemData = itemLevel_1.AddComponent<ItemShopData>();
        itemData.CreateItemShopData(startLevel, 150, "Use for 5 heart");
        this.itemDataList.Add(itemData);
    }

    public override void CheckIsSoldOut(){
    }

    public override void SetNewItemData(){
        //this.LoadPlayerData();//Debug.Log("item. level: "+this.level+", max: "+this.levelMax);
        // Now I use this fast way, but it can change by use foreach
        this.cost = itemDataList[0].Cost;
        this.SetTxtCost(this.cost.ToString());
        this.SetTxtBuy("BUY");
        this.SetTxtInfor(itemDataList[this.level].Infor);
    }
}
