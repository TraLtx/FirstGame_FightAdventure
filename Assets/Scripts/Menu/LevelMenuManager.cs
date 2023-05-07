using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuManager : GameMonoBehaviour
{
    [SerializeField] protected SceneChanger sceneChanger;

    protected override void LoadComponents(){
        this.LoadSceneChanger();
    }

    protected virtual void LoadSceneChanger(){//Debug.Log(GameObject.Find("SceneChanger0").name);
        if(this.sceneChanger != null) return;
        this.sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();//Debug.Log(GameObject.Find("SceneChanger").name);
    }

    public virtual void BtnLevel_1Click(){
        this.GoToLevel(Constant.SCENE_LEVEL_1);
    }

    protected virtual void GoToLevel(string levelName){
        this.sceneChanger.ChangeScene(levelName);
    }
}
