using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxPowerReceiver : BoxPowerReceiver
{
    [SerializeField] protected AudioSource _audioSource;

    protected override void LoadComponents()
    {Debug.Log("PlayerBoxPowerReceiver.LoadComponents()");
        base.LoadComponents();
        this.LoadAudioSource();
    }
    protected virtual void LoadAudioSource(){
        if(this._audioSource != null) return;
        this._audioSource = GetComponent<AudioSource>();
    }

    public override void AddPowerUpgradePoint(int boxPower){
        base.AddPowerUpgradePoint(boxPower);
        this.PlaySFX();
    }

    protected virtual void PlaySFX(){
        this._audioSource.Play();
    }
}
