using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : GameMonoBehaviour
{
    private static MainMenuManager instance;
    public static MainMenuManager Instance => instance;
    [SerializeField] protected Transform sceneChanger;

    protected override void Awake(){
        base.Awake();
        if(instance != null) return;
        instance = this;
    }

    protected override void LoadComponents(){
        this.LoadSceneChanger();
    }

    protected virtual void LoadSceneChanger(){
        if(this.sceneChanger != null) return;
        this.sceneChanger = GameObject.Find("SceneChanger").transform;
        this.sceneChanger.gameObject.SetActive(false);
    }

    public virtual void BtnSinglePlayClick(){Debug.Log("clicked");
        this.sceneChanger.GetComponent<SceneChanger>().ChangeScene();
    }

    public virtual void LoadNextScene(){
        SceneManager.LoadScene("MainPlay");
    }

    public virtual void TurnOnSceneChanger(){
        this.sceneChanger.gameObject.SetActive(true);
    }
}
