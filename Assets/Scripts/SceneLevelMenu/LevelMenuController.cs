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

    //---Player-------------------------------------------
    [SerializeField] protected Image imgChar;

    //---Shop---------------------------------------------
    [SerializeField] protected int amountHeart;
    [SerializeField] protected Text txtAmountHeart;

    [SerializeField] protected Transform itemUlti_1;
    [SerializeField] protected Transform itemUlti_2;

    // [SerializeField] protected List<int> itemSkills;
    // [SerializeField] protected List<ShopItem> items;

    protected override void Awake(){
        base.Awake();PlayerPrefs.SetInt(Constant.SAVE_COINS, 1000);
        if(instance != null) return;
        instance = this;
    }

    protected override void LoadComponents(){
        this.LoadSceneChanger();
        this.LoadSwitchTab();
        this.LoadTxtCoins();
        this.LoadImgChar();
        this.LoadTxtAmountHeart();
        this.LoadItemUlti1();
        this.LoadItemUlti2();

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

    protected virtual void LoadImgChar(){
        if(this.imgChar != null) return;
        this.imgChar = transform.Find("Canvas/Pnl_PageContent/Player/Imag_CharIcon").GetComponent<Image>();
    }

    protected virtual void LoadTxtAmountHeart(){
        if(this.txtAmountHeart != null) return;
        this.txtAmountHeart = transform.Find("Canvas/Pnl_Player_Item/Heart/Txt_Amount").GetComponent<Text>();
    }

    protected virtual void LoadItemUlti1(){
        if(this.itemUlti_1 != null) return;
        this.itemUlti_1 = transform.Find("Canvas/Pnl_PageContent/Shop/Skills/Skills_Container/Item_Ulti/Ulti1");
    }

    protected virtual void LoadItemUlti2(){
        if(this.itemUlti_2 != null) return;
        this.itemUlti_2 = transform.Find("Canvas/Pnl_PageContent/Shop/Skills/Skills_Container/Item_Ulti/Ulti2");
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

    //---SwitchTab---------------------------------------
    public virtual void SwitchTabLevels(){
        this.switchTab.ChangeToTab("Levels");
    }
    public virtual void SwitchTabPlayer(){
        if(PlayerPrefs.GetInt(Constant.SAVE_CHAR) == 1){
            this.imgChar.sprite = Resources.Load<Sprite>("Sprites/Box_Char_Green");
        }else if(PlayerPrefs.GetInt(Constant.SAVE_CHAR) == 2){
            this.imgChar.sprite = Resources.Load<Sprite>("Sprites/Box_Char_Yellow");
        }

        this.switchTab.ChangeToTab("Player");
    }
    public virtual void SwitchTabShop(){
        this.switchTab.ChangeToTab("Shop");
        if(PlayerPrefs.GetInt(Constant.SAVE_CHAR) == 1){
            this.itemUlti_1.gameObject.SetActive(true);
            this.itemUlti_2.gameObject.SetActive(false);
        }else if(PlayerPrefs.GetInt(Constant.SAVE_CHAR) == 2){
            this.itemUlti_1.gameObject.SetActive(false);
            this.itemUlti_2.gameObject.SetActive(true);
        }
        // this.LoadData();
    }

    //---Player-------------------------------------------------
    public virtual void ChangeChar(){
        if(PlayerPrefs.GetInt(Constant.SAVE_CHAR) == 1){
            PlayerPrefs.SetInt(Constant.SAVE_CHAR, 2);
            this.imgChar.sprite = Resources.Load<Sprite>("Sprites/Box_Char_Yellow");
        }else if(PlayerPrefs.GetInt(Constant.SAVE_CHAR) == 2){
            PlayerPrefs.SetInt(Constant.SAVE_CHAR, 1);
            this.imgChar.sprite = Resources.Load<Sprite>("Sprites/Box_Char_Green");
        }
    }

    //---Shop---------------------------------------------------
    public virtual void BuyShield(){
        ItemShield itemShield = ItemShield.Instance;
        int currentShield = PlayerPrefs.GetInt(Constant.SAVE_SHIELD_LEVEL);
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

    }

    public virtual void BuyUlti1(){
        ItemUlti1 itemUlti = ItemUlti1.Instance;
        int currentUlti = PlayerPrefs.GetInt(Constant.SAVE_ULTI_1_LEVEL);

        if(itemUlti.GetCost() > this.coins){
            SystemNotify.Instance.ShowNotify("Not enough money!");
            return;
        }

        this.coins -= itemUlti.GetCost();
        currentUlti ++;

        Debug.Log("AfterBuy: coins-"+this.coins+" ulti-"+currentUlti);

        PlayerPrefs.SetInt(Constant.SAVE_COINS, this.coins);
        PlayerPrefs.SetInt(Constant.SAVE_ULTI_1_LEVEL, currentUlti);
        this.UpdateTxtCoin();
        
        itemUlti.SetNewItemData();
    }

    public virtual void BuyUlti2(){
        ItemUlti2 itemUlti = ItemUlti2.Instance;
        int currentUlti = PlayerPrefs.GetInt(Constant.SAVE_ULTI_2_LEVEL);

        if(itemUlti.GetCost() > this.coins){
            SystemNotify.Instance.ShowNotify("Not enough money!");
            return;
        }

        this.coins -= itemUlti.GetCost();
        currentUlti ++;

        Debug.Log("AfterBuy: coins-"+this.coins+" ulti-"+currentUlti);

        PlayerPrefs.SetInt(Constant.SAVE_COINS, this.coins);
        PlayerPrefs.SetInt(Constant.SAVE_ULTI_2_LEVEL, currentUlti);
        this.UpdateTxtCoin();
        
        itemUlti.SetNewItemData();
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
    }


    // protected virtual void LoadData(){

    //     // this.items.Add(transform.Find("Canvas/Pnl_PageContent/Shop/Skills/Skills_Container/Item_Shield").GetComponent<ShopItem>());
    // }

}
