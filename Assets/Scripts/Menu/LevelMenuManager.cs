using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuManager : GameMonoBehaviour
{
    [SerializeField] protected SceneChanger sceneChanger;
    [SerializeField] protected LevelMenuSwitchTab switchTab;

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

    public virtual void BtnLevel_1Click(){
        this.GoToLevel(Constant.SCENE_LEVEL_1);
    }

    protected virtual void GoToLevel(string levelName){
        this.sceneChanger.ChangeScene(levelName);
    }

    public virtual void TabLevelClick(){
        this.switchTab.ChangeToTab("Levels");
    }
    public virtual void TabPlayerClick(){
        this.switchTab.ChangeToTab("Player");
    }
    public virtual void TabShopClick(){
        this.switchTab.ChangeToTab("Shop");
    }
}
