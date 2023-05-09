using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : SpawnerWithPool
{
    private static CoinSpawner instance;
    public static CoinSpawner Instance {get => instance;}

    protected override void Awake(){
        base.Awake();
        if(instance != null) return;
        instance = this;
    }
    public static string silverCoin = "Silver_Coin";
}
