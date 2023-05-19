using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuButtonClick : GameMonoBehaviour
{
    [SerializeField] protected LevelMenuController controller;

    protected virtual void Start(){
        this.controller = LevelMenuController.Instance;
    }

    public virtual void BtnMainMenuClick(){
        this.controller.GoToMainMenu();
    }

    public virtual void TabLevelsClick(){
        this.controller.SwitchTabLevels();
    }

    public virtual void TabPlayerClick(){
        this.controller.SwitchTabPlayer();
    }

    public virtual void TabShopClick(){
        this.controller.SwitchTabShop();
    }

    public virtual void BtnLevel_1Click(){
        this.controller.GoToLevel(Constant.SCENE_LEVEL_1);
    }

    public virtual void BtnItemShieldClick(){
        this.controller.BuyShield();
    }
}
