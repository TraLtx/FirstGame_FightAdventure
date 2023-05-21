using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuController : GameMonoBehaviour
{
    private static LevelMenuController instance;
    public static LevelMenuController Instance => instance;

    [SerializeField] protected SceneChanger sceneChanger;
    [SerializeField] protected LevelMenuSwitchTab switchTab;

    [SerializeField] protected int coins;
    [SerializeField] protected Text txtCoins;
    [SerializeField] protected int amountHeart;
    [SerializeField] protected Text txtAmountHeart;

    [SerializeField] protected List<int> itemSkills;
    [SerializeField] protected List<ShopItem> items;

    protected override void Awake(){
        base.Awake();PlayerPrefs.SetInt(Constant.SAVE_COINS, 1000);
        if(instance != null) return;
        instance = this;
    }

    protected override void LoadComponents(){
        this.LoadSceneChanger();
        this.LoadSwitchTab();
        this.LoadTxtCoins();
        this.LoadTxtAmountHeart();

        // this.LoadData();
    }

    protected virtual void LoadSceneChanger(){//Debug.Log(GameObject.Find("SceneChanger0").name);
        if(this.sceneChanger != null) return;
        this.sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();//Debug.Log(GameObject.Find("SceneChanger").name);
    }

    protected virtual void LoadSwitchTab(){
        if(this.switchTab != null) return;
        this.switchTab = GetComponentInChildren<LevelMenuSwitchTab>();
    }

    protected virtual void LoadTxtCoins(){
        if(this.txtCoins != null) return;
        this.txtCoins = transform.Find("Canvas/Pnl_Coin/Txt_Coins").GetComponent<Text>();
    }

    protected virtual void LoadTxtAmountHeart(){
        if(this.txtAmountHeart != null) return;
        this.txtAmountHeart = transform.Find("Canvas/Pnl_Player_Item/Heart/Txt_Amount").GetComponent<Text>();
    }

    protected virtual void Start(){
        this.UpdateTxtCoin();
        this.UpdateTxtAmountHeart();
    }

    protected virtual void UpdateTxtCoin(){
        this.coins = PlayerPrefs.GetInt(Constant.SAVE_COINS);
        this.txtCoins.text = this.coins.ToString();
    }

    protected virtual void UpdateTxtAmountHeart(){
        this.amountHeart = PlayerPrefs.GetInt(Constant.SAVE_HEART_ITEMS);
        this.txtAmountHeart.text = this.amountHeart.ToString();
    }

    //===PUBLIC METHODs===========================================
    public virtual void GoToMainMenu(){
        this.sceneChanger.ChangeScene(Constant.SCENE_MAIN_MENU);
    }

    public virtual void GoToLevel(string levelName){
        this.sceneChanger.ChangeScene(levelName);
    }

    public virtual void SwitchTabLevels(){
        this.switchTab.ChangeToTab("Levels");
    }

    public virtual void SwitchTabPlayer(){
        this.switchTab.ChangeToTab("Player");
    }

    public virtual void SwitchTabShop(){
        this.switchTab.ChangeToTab("Shop");
        // this.LoadData();
    }

    public virtual void BuyShield(){
        ItemShield itemShield = ItemShield.Instance;
        int currentShield = PlayerPrefs.GetInt(Constant.SAVE_SHIELD_LEVEL);
// Debug.Log("BeforeBuy: coins-"+this.coins+" shiledCost-"+itemShield.GetCost());
        if(itemShield.GetCost() > this.coins){
            SystemNotify.Instance.ShowNotify("Not enough money!");
            return;
        }

        this.coins -= itemShield.GetCost();
        currentShield ++;

        Debug.Log("AfterBuy: coins-"+this.coins+" shiled-"+currentShield);

        PlayerPrefs.SetInt(Constant.SAVE_COINS, this.coins);
        PlayerPrefs.SetInt(Constant.SAVE_SHIELD_LEVEL, currentShield);
        this.UpdateTxtCoin();
        
        itemShield.SetNewItemData();

        // SystemNotify.Instance.ShowNotify("Buy successfully!");
    }

    public virtual void BuyUlti(){
        ItemUlti itemUlti = ItemUlti.Instance;
        int currentUlti = PlayerPrefs.GetInt(Constant.SAVE_ULTI_LEVEL);

        if(itemUlti.GetCost() > this.coins){
            SystemNotify.Instance.ShowNotify("Not enough money!");
            return;
        }

        this.coins -= itemUlti.GetCost();
        currentUlti ++;

        Debug.Log("AfterBuy: coins-"+this.coins+" ulti-"+currentUlti);

        PlayerPrefs.SetInt(Constant.SAVE_COINS, this.coins);
        PlayerPrefs.SetInt(Constant.SAVE_ULTI_LEVEL, currentUlti);
        this.UpdateTxtCoin();
        
        itemUlti.SetNewItemData();

        // SystemNotify.Instance.ShowNotify("Buy successfully!");
    }

    public virtual void BuyHeart(){
        ItemHeart itemHeart = ItemHeart.Instance;

        if(itemHeart.GetCost() > this.coins){
            SystemNotify.Instance.ShowNotify("Not enough money!");
            return;
        }

        this.coins -= itemHeart.GetCost();
        this.amountHeart ++;

        Debug.Log("AfterBuy: coins-"+this.coins+" heart-"+amountHeart);

        PlayerPrefs.SetInt(Constant.SAVE_COINS, this.coins);
        PlayerPrefs.SetInt(Constant.SAVE_HEART_ITEMS, this.amountHeart);
        this.UpdateTxtCoin();
        this.UpdateTxtAmountHeart();

        // SystemNotify.Instance.ShowNotify("Buy successfully!");
    }


    // protected virtual void LoadData(){

    //     // this.items.Add(transform.Find("Canvas/Pnl_PageContent/Shop/Skills/Skills_Container/Item_Shield").GetComponent<ShopItem>());
    // }

}
