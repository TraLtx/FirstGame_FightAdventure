using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : GameMonoBehaviour
{
    public virtual void TurnOff(){
        this.gameObject.SetActive(false);
        MainMenuManager.Instance.TurnOnSceneChanger();
    }

}
