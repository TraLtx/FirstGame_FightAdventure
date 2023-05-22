using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : GameMonoBehaviour
{
    private static MainMenuController instance;
    public static MainMenuController Instance => instance;

    [SerializeField] protected Transform sceneChanger;

    [SerializeField] protected Transform pnlChooseChar;
    [SerializeField] protected Transform bgChooseGreen;
    [SerializeField] protected Transform bgChooseYellow;

    [SerializeField] protected int charIndex = 0;

    protected override void Awake(){
        base.Awake();
        if(instance != null) return;
        instance = this;
    }

    protected override void LoadComponents(){
        this.LoadSceneChanger();
        this.LoadPnlChooseChar();
        this.LoadBgChooseChar();
    }

    protected virtual void LoadSceneChanger(){
        if(this.sceneChanger != null) return;
        this.sceneChanger = GameObject.Find("SceneChanger").transform;
    }

    protected virtual void LoadPnlChooseChar(){
        if(this.pnlChooseChar != null) return;
        this.pnlChooseChar = transform.Find("MenuCanvas/Pnl_ChooseCharacter");
        this.pnlChooseChar.gameObject.SetActive(false);
    }

    protected virtual void LoadBgChooseChar(){
        if(this.bgChooseGreen != null && this.bgChooseYellow != null) return;

        this.bgChooseGreen = transform.Find("MenuCanvas/Pnl_ChooseCharacter/Bg_ChooseGreen");
        this.bgChooseYellow = transform.Find("MenuCanvas/Pnl_ChooseCharacter/Bg_ChooseYellow");

        this.bgChooseGreen.gameObject.SetActive(false);
        this.bgChooseYellow.gameObject.SetActive(false);
    }

    //===PUBLIC METHODs=========================================

    public virtual void SinglePlay(){
        if(PlayerPrefs.GetInt(Constant.SAVE_CHAR) == 0)
            this.pnlChooseChar.gameObject.SetActive(true);
        else this.sceneChanger.GetComponent<SceneChanger>().ChangeScene(Constant.SCENE_LEVEL_MENU);
    }

    public virtual void ExitChooseChar(){
        this.pnlChooseChar.gameObject.SetActive(false);
    }

    public virtual void ChooseGreenChar(){
        this.bgChooseYellow.gameObject.SetActive(false);
        this.bgChooseGreen.gameObject.SetActive(true);
        this.charIndex = 1;
    }

    public virtual void ChooseYellowChar(){ 
        this.bgChooseGreen.gameObject.SetActive(false);
        this.bgChooseYellow.gameObject.SetActive(true);
        this.charIndex = 2;
    }

    public virtual void ComfirmChar(){
        if(this.charIndex == 0){
            SystemNotify.Instance.ShowNotify("Choose your character!");
            return;
        }
        PlayerPrefs.SetInt("CharacterIndex", this.charIndex);
        this.sceneChanger.GetComponent<SceneChanger>().ChangeScene(Constant.SCENE_LEVEL_MENU);
    }

    public virtual void MultiPlay(){
        SystemNotify.Instance.ShowNotify("Function in development. I will come back later.");
    }

    public virtual void QuitApp(){
        Application.Quit();
    }
}
