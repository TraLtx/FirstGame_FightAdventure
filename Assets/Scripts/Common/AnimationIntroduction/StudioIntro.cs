using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudioIntro : GameMonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected SceneChanger sceneChanger;

    protected override void LoadComponents(){
        this.LoadSceneChanger();
        this.LoadAudioSource();
    }

    protected virtual void LoadSceneChanger(){
        if(this.sceneChanger != null) return;
        this.sceneChanger = FindObjectOfType<SceneChanger>();
    }
    protected virtual void LoadAudioSource(){
        if(this.audioSource != null) return;
        this.audioSource = FindObjectOfType<AudioSource>();
    }

    protected virtual void Start(){
        this.audioSource.PlayDelayed(0.5f);
    }

    public virtual void TurnOff(){
        this.sceneChanger.ChangeScene(Constant.SCENE_MAIN_MENU);
    }
}
