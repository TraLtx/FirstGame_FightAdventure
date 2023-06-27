using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamReceiver : DamReceiver//, IHpBarInterface
{
    [SerializeField] protected int healByselfPoint = 1;
    [SerializeField] protected float healDelay = 0.5f;
    [SerializeField] protected bool canHealBySelf = true;
    [SerializeField] protected int playerHeartBox;

    [SerializeField] protected AudioSource _audioSource;

    [SerializeField] protected HeartInventory heartInventory;

    protected override void LoadComponents()
    {Debug.Log("PlayerDamReceiver.LoadComponents()");
        base.LoadComponents();
        this.LoadHeartInventory();
        this.LoadAudioSource();
    }

    protected virtual void LoadHeartInventory(){
        if(this.heartInventory != null) return;
        this.heartInventory = transform.parent.GetComponentInChildren<HeartInventory>();
    }
    protected virtual void LoadAudioSource(){
        if(this._audioSource != null) return;
        this._audioSource = GetComponent<AudioSource>();
    }

    protected virtual void Start(){
        this.GetPlayerDataHeart();
        this.heartInventory.UpdateInventory(this.playerHeartBox);
    }

    protected virtual void FixedUpdate(){//Debug.Log("InputManager.Instance.GetHealStatus():"+InputManager.Instance.GetHealStatus());
        if(InputManager.Instance.GetHealStatus() && this.canHealBySelf && this.GetPlayerDataHeart() > 0){
            Debug.Log("HEAL By Self");
            StartCoroutine(this.HealBySelf());
        }
           
    }

    protected virtual IEnumerator HealBySelf(){

        this.AddHp(this.healByselfPoint);
        this.playerHeartBox -= 1;
        if(this.playerHeartBox < 0) this.playerHeartBox = 0;
        this.heartInventory.UpdateInventory(this.playerHeartBox);
        PlayerPrefs.SetInt(Constant.SAVE_HEART_ITEMS, this.playerHeartBox);

        this.canHealBySelf = false;
        yield return new WaitForSeconds(healDelay);
        this.canHealBySelf = true;
    }

    protected virtual int GetPlayerDataHeart(){
        this.playerHeartBox = PlayerPrefs.GetInt(Constant.SAVE_HEART_ITEMS);
        return this.playerHeartBox;
    }

    public override void Deduct(int subNum){
        // Debug.Log(subNum);
        if(subNum <= transform.parent.GetComponent<PlayerCtrl>().GetShieldStatus()) return;
        base.Deduct(subNum);
        // Debug.Log(transform.parent.name);
        transform.parent.GetComponent<PlayerCtrl>().PlayerDangerEffect.NotifyDanger();
    }
    public override void AddHp(int addNum){
        base.AddHp(addNum);
        this.PlaySFX();
    }
    protected override void OnDead(){
        Destroy(transform.parent.gameObject);
        GameController.Instance.Die();
    }

    protected override void LoadHpBar(){
        if(this.hpBar != null) return;
        this.hpBar = transform.parent.GetComponentInChildren<UIHpBar>();
    }

    protected override void SetHp(){
        this.maxHp = 10;
        this.hp = maxHp;
    }

    protected virtual void PlaySFX(){
        this._audioSource.Play();
    }
}
