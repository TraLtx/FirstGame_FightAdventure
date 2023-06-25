using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelDie : GameMonoBehaviour
{
    [SerializeField] protected Text txtCoin;
    [SerializeField] protected Text txtBoxGun;
    [SerializeField] protected Text txtBoxPower;

    protected override void LoadComponents(){
        this.LoadTxtCoin();
        this.LoadTxtBoxGun();
        this.LoadTxtBoxPower();
    }
    protected virtual void LoadTxtCoin(){
        if(this.txtCoin != null) return;
        this.txtCoin = transform.Find("Bg_Sumary/Col1/Txt_CoinCollect").GetComponent<Text>();
        this.txtCoin.text = "-";
    }
    protected virtual void LoadTxtBoxGun(){
        if(this.txtBoxGun != null) return;
        this.txtBoxGun = transform.Find("Bg_Sumary/Col2/Txt_BoxGunCollect").GetComponent<Text>();
        this.txtBoxGun.text = "-";
    }
    protected virtual void LoadTxtBoxPower(){
        if(this.txtBoxPower != null) return;
        this.txtBoxPower = transform.Find("Bg_Sumary/Col3/Txt_BoxPowerCollect").GetComponent<Text>();
        this.txtBoxPower.text = "-";
    }

    public virtual void SetCoinsCollect(int coins){
        this.txtCoin.text = coins.ToString();
    }
    public virtual void SetBoxGunsCollect(int boxGun){
        this.txtBoxGun.text = boxGun.ToString();
    }
    public virtual void SetBoxPowersCollect(int boxPower){
        this.txtBoxPower.text = boxPower.ToString();
    }
}
