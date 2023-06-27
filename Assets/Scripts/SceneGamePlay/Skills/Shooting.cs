using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooting : GameMonoBehaviour
{
    [SerializeField] protected float shootDelayMax;
    [SerializeField] protected float shootDelay;
    [SerializeField] protected float delayUp;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected float shootDelayMin;

    [SerializeField] protected int shootDamMax;
    [SerializeField] protected int shootPowerMax;

    [SerializeField] protected int shootDam = 1;
    [SerializeField] protected int shootPower = 1;

    [SerializeField] protected string bulletName;
    [SerializeField] protected Transform shootingPoint;

    [SerializeField] protected bool useAble;

    protected override void ResetValue(){
        this.SetParentCtrl();
        this.SetShootDelayMax();
        this.SetDelayUp();
        this.SetShootDelayMin();
        this.SetShootDamMax();
        this.SetShootPowerMax();
        this.SetBullet();
        this.SetShootingPoint();
        this.SetUseAble();
    }

    protected abstract void SetParentCtrl();
    protected abstract void SetShootDelayMax();
    protected abstract void SetDelayUp();
    protected abstract void SetShootDelayMin();
    protected abstract void SetShootDamMax();
    protected abstract void SetShootPowerMax();
    protected abstract void SetBullet();
    protected abstract void SetShootingPoint();
    protected abstract void SetUseAble();
    protected abstract bool GetShootAble();

    protected virtual void FixedUpdate(){
        if(!this.useAble) return;

        if(this.shootTimer < this.shootDelay){
            this.shootTimer += Time.fixedDeltaTime;
            
            this.UpdateSlider();
            return;
        }

        if(! this.GetShootAble()) return;
        this.Shoot();
    }

    protected virtual void UpdateSlider(){
        //Override
    }

    protected virtual float GetSliderValue(){
        float value = 1 - (this.shootTimer/this.shootDelay);
        if(value > 0) return value;
        return 0;
    }

    protected virtual void Shoot(){
        // if(this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;
        // this.UpdateSlider();


        Transform newBullet = BulletSpawner.Instance.Spawn(this.bulletName, this.shootingPoint.position, this.shootingPoint.parent.rotation);
        if(newBullet == null){
            Debug.LogWarning("Can not Spawn Bullet");
            return;
        }
        newBullet.gameObject.SetActive(true);
        newBullet.GetComponent<BulletCtrl>().SetShooter(transform.parent);
        newBullet.GetComponent<BulletCtrl>().SetDamage(this.shootDam);
        newBullet.GetComponent<BulletCtrl>().ResetBorn();

    }
    public virtual void AddShootDam(int dam){
        this.shootDam += dam;
        if(this.shootDam > this.shootDamMax) this.shootDam = this.shootDamMax;
    }

    public virtual void AddShootPower(int power){
        this.shootPower += power;
        if(this.shootPower > this.shootPowerMax) this.shootPower = this.shootPowerMax;

        this.shootDelay = this.shootDelayMax - this.shootPower * this.delayUp;
    }
}