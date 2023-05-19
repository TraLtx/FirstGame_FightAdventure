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

    [SerializeField] protected Text txtCoins;

    [SerializeField] protected List<int> itemSkills;
    [SerializeField] protected List<ShopItem> items;

    protected override void Awake(){
        base.Awake();
        if(instance != null) return;
        instance = this;
    }

    protected override void LoadComponents(){
        this.LoadSceneChanger();
        this.LoadSwitchTab();
        this.LoadTxtCoins();

        this.LoadData();
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

    protected virtual void Start(){
        int coins = PlayerPrefs.GetInt("PlayerCoins");Debug.Log("Coins: "+coins);
        this.txtCoins.text = coins.ToString();
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
        if(itemSkills[0] > PlayerPrefs.GetInt("PlayerCoins")){
            SystemNotify.Instance.ShowNotify("Not enough money!");
            return;
        }
        int shiled = PlayerPrefs.GetInt("Shield");
        shiled ++;
        PlayerPrefs.SetInt("Shiled", shiled);

        SystemNotify.Instance.ShowNotify("Buy successfully!");
    }


    protected virtual void LoadData(){

        this.items.Add(transform.Find("Canvas/Pnl_PageContent/Shop/Skills/Skills_Container/Item_Shield").GetComponent<ShopItem>());

        this.itemSkills.Add(15);
        this.items[0].SetTxtCost("15");
        this.items[0].SetTxtBuy("Unlock");
    }

}
