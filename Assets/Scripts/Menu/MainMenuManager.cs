using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : GameMonoBehaviour
{
    private static MainMenuManager instance;
    public static MainMenuManager Instance => instance;
    [SerializeField] protected Transform sceneChanger;

    [SerializeField] protected Transform pnlChooseChar;
    [SerializeField] protected Transform bgChooseGreen;
    [SerializeField] protected Transform bgChooseYellow;
    // [SerializeField] protected Transform btnGreenChar;
    // [SerializeField] protected Transform btnYellowChar;

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
        // this.LoadBtnChar();
    }

    protected virtual void LoadSceneChanger(){
        if(this.sceneChanger != null) return;
        this.sceneChanger = GameObject.Find("SceneChanger").transform;
        this.sceneChanger.gameObject.SetActive(false);
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

    // protected virtual void LoadBtnChar(){
    //     if(this.btnGreenChar != null && this.btnYellowChar != null) return;

    //     this.btnGreenChar = transform.Find("MenuCanvas/Pnl_ChooseCharacter/Btn_GreenChar");
    //     this.btnYellowChar = transform.Find("MenuCanvas/Pnl_ChooseCharacter/Btn_YellowChar");
    // }

    public virtual void BtnSinglePlayClick(){//Debug.Log("clicked");
        // this.sceneChanger.GetComponent<SceneChanger>().ChangeScene();
        this.pnlChooseChar.gameObject.SetActive(true);
    }

    public virtual void BtnExitPnlChooseCharClick(){
        this.pnlChooseChar.gameObject.SetActive(false);
    }

    public virtual void BtnGreenCharClick(){
        this.bgChooseYellow.gameObject.SetActive(false);
        this.bgChooseGreen.gameObject.SetActive(true);
        this.charIndex = 1;
    }

    public virtual void BtnYellowCharClick(){ 
        this.bgChooseGreen.gameObject.SetActive(false);
        this.bgChooseYellow.gameObject.SetActive(true);
        this.charIndex = 2;
    }

    public virtual void BtnChooseCharOkClick(){
        if(this.charIndex == 0){
            SystemNotify.Instance.ShowNotify("Choose your character!");
            return;
        }
        PlayerPrefs.SetInt("CharacterIndex", this.charIndex);
        this.sceneChanger.GetComponent<SceneChanger>().ChangeScene();
    }

    public virtual void LoadNextScene(){
        SceneManager.LoadScene("MainPlay");
    }

    public virtual void TurnOnSceneChanger(){
        this.sceneChanger.gameObject.SetActive(true);
    }
}
