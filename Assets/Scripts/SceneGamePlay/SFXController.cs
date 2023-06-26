using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : GameMonoBehaviour
{
    protected static SFXController instance;
    public static SFXController Instance {get => instance;}

    [SerializeField] protected AudioSource _audioSource;

    [SerializeField] protected AudioClip clipBoom;
    [SerializeField] protected AudioClip clipPlayerShoot;
    [SerializeField] protected AudioClip clipPlayerLaser;


    protected override void Awake(){
        base.Awake();
        if(instance != null) return;
        instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAudioSource();
    }
    protected virtual void LoadAudioSource(){
        if(this._audioSource != null) return;
        this._audioSource = GetComponent<AudioSource>();
    }

    public virtual void PlaySFX_Boom(){
        this._audioSource.PlayOneShot(this.clipBoom);
    }

    public virtual void PlaySFX_PlayerShoot(){
        this._audioSource.PlayOneShot(this.clipPlayerShoot);
    }

    public virtual void PlaySFX_PlayerLaser(){
        this._audioSource.PlayOneShot(this.clipPlayerLaser);
    }
}
