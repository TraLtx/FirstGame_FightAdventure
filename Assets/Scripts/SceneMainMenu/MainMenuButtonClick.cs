using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonClick : GameMonoBehaviour
{
    [SerializeField] protected MainMenuController controller;

    protected virtual void Start(){
        this.controller = MainMenuController.Instance;
    }

    public virtual void BtnSinglePlayClick(){
        this.controller.SinglePlay();
    }

    public virtual void BtnExitPnlChooseCharClick(){
        this.controller.ExitChooseChar();
    }

    public virtual void BtnGreenCharClick(){
        this.controller.ChooseGreenChar();
    }

    public virtual void BtnYellowCharClick(){ 
        this.controller.ChooseYellowChar();
    }

    public virtual void BtnComfirmCharClick(){
        this.controller.ComfirmChar();
    }
}
