using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinReceiver : CoinReceiver
{
    [SerializeField] protected AudioSource _audioSource;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAudioSource();
    }
    protected virtual void LoadAudioSource(){
        if(this._audioSource != null) return;
        this._audioSource = GetComponent<AudioSource>();
    }

    public override void AddCoin(int coinPoint){
        base.AddCoin(coinPoint);
        this.PlaySFX();
    }

    protected virtual void PlaySFX(){
        this._audioSource.Play();
    }
}
