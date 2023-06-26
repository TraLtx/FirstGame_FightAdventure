using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassLevelPanel : GameMonoBehaviour
{
    [SerializeField] protected Animator animator;

    [SerializeField] protected Text txtCoin;
    [SerializeField] protected Text txtBoxGun;
    [SerializeField] protected Text txtBoxPower;

    protected override void LoadComponents(){
        this.LoadAnimator();
        this.LoadTxtCoin();
        this.LoadTxtBoxGun();
        this.LoadTxtBoxPower();
    }
    protected virtual void LoadAnimator(){
        if(this.animator != null) return;
        this.animator = transform.GetComponent<Animator>();
    }
    protected virtual void LoadTxtCoin(){
        if(this.txtCoin != null) return;
        this.txtCoin = transform.Find("Bg_Sumary/Row1/Txt_CoinTotal").GetComponent<Text>();
        this.txtCoin.text = "-/-";
    }
    protected virtual void LoadTxtBoxGun(){
        if(this.txtBoxGun != null) return;
        this.txtBoxGun = transform.Find("Bg_Sumary/Row2/Txt_BoxGunTotal").GetComponent<Text>();
        this.txtBoxGun.text = "-/-";
    }
    protected virtual void LoadTxtBoxPower(){
        if(this.txtBoxPower != null) return;
        this.txtBoxPower = transform.Find("Bg_Sumary/Row3/Txt_BoxPowerTotal").GetComponent<Text>();
        this.txtBoxPower.text = "-/-";
    }

    public virtual void SetCoinsTotal(int coins, int total){
        this.txtCoin.text = coins.ToString() + "/" + total.ToString();
    }
    public virtual void SetBoxGunsTotal(int boxGun, int total){
        this.txtBoxGun.text = boxGun.ToString() + "/" + total.ToString();
    }
    public virtual void SetBoxPowersTotal(int boxPower, int total){
        this.txtBoxPower.text = boxPower.ToString() + "/" + total.ToString();
    }

    public virtual void ShowPanel(){
        this.animator.SetTrigger("Show");
    }
}
