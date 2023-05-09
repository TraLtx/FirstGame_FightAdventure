using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayButtonClick : GameMonoBehaviour
{
    [SerializeField] protected GameController controller;

    protected virtual void Start(){
        this.controller = GameController.Instance;
    }

    public virtual void BtnPauseClick(){
        this.controller.PauseGame();
    }

    public virtual void BtnContinueClick(){
        this.controller.ContinueGame();
    }

    public virtual void BtnRestartClick(){
        this.controller.RestartGame();
    }

    public virtual void BtnLevelMenuClick(){
        this.controller.GotoSceneLevelMenu();
    }
}
