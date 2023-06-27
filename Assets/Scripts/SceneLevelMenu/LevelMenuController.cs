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

    [SerializeField] protected List<Button> buttonLevels;
    [SerializeField] protected int coins;
    [SerializeField] protected Text txtCoins;
    [SerializeField] protected int boxGuns;
    [SerializeField] protected Text txtBoxGuns;
    [SerializeField] protected int boxPowers;
    [SerializeField] protected Text txtBoxPowers;

    //---Player-------------------------------------------
    [SerializeField] protected Image imgChar;

    //---Shop---------------------------------------------
    [SerializeField] protected ShopSkillContainer shopContainer;
    [SerializeField] protected int amountHeart;
    [SerializeField] protected Text txtAmountHeart;

    [SerializeField] protected Transform itemUlti_1;
    [SerializeField] protected Transform itemUlti_2;

    // [SerializeField] protected List<int> itemSkills;
    // [SerializeField] protected List<ShopItem> items;

    protected override void Awake(){
        base.Awake();

        if(instance != null) return;
        instance = this;
    }

    protected override void LoadComponents(){
        this.LoadSceneChanger();
        this.LoadSwitchTab();

        this.LoadButtonLevels();
        this.LoadTxtCoins();
        this.LoadTxtBoxGuns();
        this.LoadTxtBoxPowers();

        this.LoadImgChar();

        this.LoadShopContainer();
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

    protected virtual void LoadButtonLevels(){
        this.buttonLevels.Clear();
        Transform levelContainer = transform.Find("Canvas/Pnl_PageContent/Levels/LevelContainer");
        foreach(Transform buttonLevel in levelContainer){
            this.buttonLevels.Add(buttonLevel.GetComponent<Button>());
        }

        PlayerPrefs.SetInt(Constant.TOTAL_LEVEL, this.buttonLevels.Count);
    }

    protected virtual void LoadTxtCoins(){
        if(this.txtCoins != null) return;
        this.txtCoins = transform.Find("Canvas/Pnl_Coin/Txt_Coins").GetComponent<Text>();
    }
    protected virtual void LoadTxtBoxGuns(){
        if(this.txtBoxGuns != null) return;
        this.txtBoxGuns = transform.Find("Canvas/Pnl_BoxGun/Txt_BoxGuns").GetComponent<Text>();
    }
    protected virtual void LoadTxtBoxPowers(){
        if(this.txtBoxPowers != null) return;
        this.txtBoxPowers = transform.Find("Canvas/Pnl_BoxPower/Txt_BoxPowers").GetComponent<Text>();
    }

    protected virtual void LoadImgChar(){
        if(this.imgChar != null) return;
        this.imgChar = transform.Find("Canvas/Pnl_PageContent/Player/Imag_CharIcon").GetComponent<Image>();
    }

    protected virtual void LoadShopContainer(){
        if(this.shopContainer != null) return;
        this.shopContainer = transform.Find("Canvas/Pnl_PageContent/Shop/Skills/Skills_Container").GetComponent<ShopSkillContainer>();
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
        this.SetUpButtonLevels();
        this.UpdateTxtCoin();
        this.UpdateTxtBoxGun();
        this.UpdateTxtBoxPower();
        this.UpdateTxtAmountHeart();
    }

    protected virtual void SetUpButtonLevels(){
        int unlockLevel = PlayerPrefs.GetInt(Constant.SAVE_UNLOCK_LEVEL, 1);
        // Debug.Log("UnlockLevel: " + unlockLevel);

        for(int i = 0; i < this.buttonLevels.Count; i++){
            if(i >= unlockLevel){
                buttonLevels[i].interactable = false;
                // Debug.Log("LockButton: " + i);
            }
        }
    }

    protected virtual void UpdateTxtCoin(){
        this.coins = PlayerPrefs.GetInt(Constant.SAVE_COINS);
        this.txtCoins.text = this.coins.ToString();
    }
    protected virtual void UpdateTxtBoxGun(){
        this.boxGuns = PlayerPrefs.GetInt(Constant.SAVE_BOX_GUN);
        this.txtBoxGuns.text = this.boxGuns.ToString();
    }
    protected virtual void UpdateTxtBoxPower(){
        this.boxPowers = PlayerPrefs.GetInt(Constant.SAVE_BOX_POWER);
        this.txtBoxPowers.text = this.boxPowers.ToString();
    }

    protected virtual void UpdateTxtAmountHeart(){
        this.amountHeart = PlayerPrefs.GetInt(Constant.SAVE_HEART_ITEMS);
        this.txtAmountHeart.text = this.amountHeart.ToString();
    }

    //===PUBLIC METHODs===========================================
    public virtual void GoToMainMenu(){
        this.sceneChanger.ChangeScene(Constant.SCENE_MAIN_MENU);
    }

    public virtual void ChooseLevel(int levelId){
        PlayerPrefs.SetInt(Constant.PLAYING_LEVEL, levelId);
        string levelName = "Level_" + levelId;
        this.GoToLevel(levelName);
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
        this.shopContainer.Reload();
        
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

        this.shopContainer.ResetSort();
    }

    //---Shop---------------------------------------------------

    public virtual void UpgradeGun(){
        Item_Gun itemGun = Item_Gun.Instance;
        int currentGun = PlayerPrefs.GetInt(Constant.SAVE_GUN_LEVEL);
        if(itemGun.GetCost() > this.boxGuns){
            SystemNotify.Instance.ShowNotify("Not enough box upgrade!");
            return;
        }

        this.boxGuns -= itemGun.GetCost();
        currentGun ++;

        Debug.Log("AfterBuy: coins-"+this.boxGuns+" gun-"+currentGun);

        PlayerPrefs.SetInt(Constant.SAVE_BOX_GUN, this.boxGuns);
        PlayerPrefs.SetInt(Constant.SAVE_GUN_LEVEL, currentGun);

        // Debug.Log("???---"+PlayerPrefs.GetInt(Constant.SAVE_BOX_GUN));
        this.UpdateTxtCoin();
        
        itemGun.SetNewItemData();

    }

    public virtual void UpgradePower(){
        Item_Power itemPower = Item_Power.Instance;
        int currentPower = PlayerPrefs.GetInt(Constant.SAVE_POWER_LEVEL);
        if(itemPower.GetCost() > this.boxPowers){
            SystemNotify.Instance.ShowNotify("Not enough box upgrade!");
            return;
        }

        this.boxPowers -= itemPower.GetCost();
        currentPower ++;

        Debug.Log("AfterBuy: coins-"+this.boxPowers+" power-"+currentPower);

        PlayerPrefs.SetInt(Constant.SAVE_BOX_POWER, this.boxPowers);
        PlayerPrefs.SetInt(Constant.SAVE_POWER_LEVEL, currentPower);
        this.UpdateTxtCoin();
        
        itemPower.SetNewItemData();

    }

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
