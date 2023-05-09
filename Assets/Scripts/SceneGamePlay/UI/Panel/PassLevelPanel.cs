using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassLevelPanel : GameMonoBehaviour
{
    [SerializeField] protected Animator animator;

    [SerializeField] protected Text txtCoin;
    [SerializeField] protected Text txtChest;

    protected override void LoadComponents(){
        this.LoadAnimator();
        this.LoadTxtCoin();
        this.LoadTxtChest();
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

    protected virtual void LoadTxtChest(){
        if(this.txtChest != null) return;
        this.txtChest = transform.Find("Bg_Sumary/Row2/Txt_ChestTotal").GetComponent<Text>();
        this.txtChest.text = "-/-";
    }

    public virtual void SetCoinsTotal(int coins, int total){
        this.txtCoin.text = coins.ToString() + "/" + total.ToString();
    }

    public virtual void SetChestsTotal(int chest, int total){
        this.txtChest.text = chest.ToString() + "/" + total.ToString();
    }

    public virtual void ShowPanel(){
        this.animator.SetTrigger("Show");
    }
}
