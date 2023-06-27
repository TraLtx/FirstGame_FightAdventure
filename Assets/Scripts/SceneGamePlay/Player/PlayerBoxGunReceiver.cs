using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoxGunReceiver : BoxGunReceiver
{
    [SerializeField] protected AudioSource _audioSource;

    protected override void LoadComponents()
    {Debug.Log("PlayerBoxGunReceiver.LoadComponents()");
        base.LoadComponents();
        this.LoadAudioSource();
    }
    protected virtual void LoadAudioSource(){
        if(this._audioSource != null) return;
        this._audioSource = GetComponent<AudioSource>();
    }
    public override void AddGunUpgradePoint(int boxGun){
        base.AddGunUpgradePoint(boxGun);
        this.PlaySFX();
    }
    protected virtual void PlaySFX(){
        this._audioSource.Play();
    }
}
