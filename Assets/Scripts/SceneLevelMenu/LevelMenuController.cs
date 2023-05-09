using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuController : GameMonoBehaviour
{
    private static LevelMenuController instance;
    public static LevelMenuController Instance => instance;

    [SerializeField] protected SceneChanger sceneChanger;
    [SerializeField] protected LevelMenuSwitchTab switchTab;

    protected override void Awake(){
        base.Awake();
        if(instance != null) return;
        instance = this;
    }

    protected override void LoadComponents(){
        this.LoadSceneChanger();
        this.LoadSwitchTab();
    }

    protected virtual void LoadSceneChanger(){//Debug.Log(GameObject.Find("SceneChanger0").name);
        if(this.sceneChanger != null) return;
        this.sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();//Debug.Log(GameObject.Find("SceneChanger").name);
    }

    protected virtual void LoadSwitchTab(){
        if(this.switchTab != null) return;
        this.switchTab = GetComponentInChildren<LevelMenuSwitchTab>();
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
    }
}
