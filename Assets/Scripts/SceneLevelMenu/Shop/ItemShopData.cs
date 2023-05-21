using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShopData : GameMonoBehaviour
{
    [SerializeField] protected int level;
    [SerializeField] public int Level{set => this.level = value; get => this.level;}
    [SerializeField] protected int cost;
    [SerializeField] public int Cost{set => this.cost = value; get => this.cost;}
    [SerializeField] protected string infor;
    [SerializeField] public string Infor{set => this.infor = value; get => this.infor;}

    public virtual void  CreateItemShopData(int level, int cost, string infor){
        this.level = level;
        this.cost = cost;
        this.infor = infor;
    }
}
