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

    //---Player------------------------------
    public virtual void BtnChangeCharClick(){
        this.controller.ChangeChar();
    }

    //---SHOP--------------------------------
    public virtual void BtnUpgradeGunClick(){
        this.controller.UpgradeGun();
    }
    public virtual void BtnUpgradePowerClick(){
        this.controller.UpgradePower();
    }
    public virtual void BtnItemShieldClick(){
        this.controller.BuyShield();
    }
    public virtual void BtnItemUlti_1_Click(){
        this.controller.BuyUlti1();
    }
    public virtual void BtnItemUlti_2_Click(){
        this.controller.BuyUlti2();
    }
    public virtual void BtnItemHeartClick(){
        this.controller.BuyHeart();
    }
}
