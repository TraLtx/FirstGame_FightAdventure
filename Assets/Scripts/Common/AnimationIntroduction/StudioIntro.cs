using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudioIntro : GameMonoBehaviour
{
    [SerializeField] protected SceneChanger sceneChanger;

    protected override void LoadComponents(){
        this.LoadSceneChanger();
    }

    protected virtual void LoadSceneChanger(){
        if(this.sceneChanger != null) return;
        this.sceneChanger = FindObjectOfType<SceneChanger>();
    }

    public virtual void TurnOff(){
        this.sceneChanger.ChangeScene(Constant.SCENE_MAIN_MENU);
    }
}
