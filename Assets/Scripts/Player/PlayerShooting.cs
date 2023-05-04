using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : PlayerAbstract
{
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;

    [SerializeField] protected int shootDamMax = 5;
    [SerializeField] protected int shootPowerMax = 5;

    [SerializeField] protected int shootDam = 1;
    [SerializeField] protected int shootPower = 1;

    [SerializeField] protected UIDamBar damBar;
    [SerializeField] protected UIPowerBar powerBar;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadDamBar();
        this.LoadPowerBar();
    }

    protected virtual void LoadDamBar(){
        if(this.damBar != null) return;
        this.damBar = transform.parent.GetComponentInChildren<UIDamBar>();
    }

    protected virtual void LoadPowerBar(){
        if(this.powerBar != null) return;
        this.powerBar = transform.parent.GetComponentInChildren<UIPowerBar>();
    }

    protected virtual void Start(){
        this.damBar.UpdateBar(this.shootDam);
        this.powerBar.UpdateBar(this.shootPower);
        this.shootDelay = 1f - this.shootPower * 0.15f;
    }

    void Update(){        
        this.Shoot();
    }

    protected bool GetShootAble()
    {
        if(!GameController.Instance.IsOnlineState) return InputManager.Instance.GetFightStatus();

        return InputManager.Instance.GetFightStatus() && playerCtrl.View.IsMine;
    }

    protected void Shoot(){
        if(this.shootTimer < this.shootDelay) this.shootTimer += Time.deltaTime;

        if(!GetShootAble()) return;

        if(this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;

        Vector3 modelScale = transform.parent.localScale;

        Quaternion rotation = new Quaternion(0,0,0,1);
        if(modelScale.x < 1){
            rotation = new Quaternion(0,0,180,1);
        }
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, playerCtrl.ShootingPoint.position, rotation);
        if(newBullet == null){
            Debug.LogWarning("Can not Spawn Bullet");
            return;
        }
        newBullet.gameObject.SetActive(true);
        newBullet.GetComponent<BulletCtrl>().SetShooter(transform.parent);
        newBullet.GetComponent<BulletCtrl>().SetDamage(this.shootDam);

    }

    public virtual void AddShootDam(int dam){
        this.shootDam += dam;
        if(this.shootDam > this.shootDamMax) this.shootDam = this.shootDamMax;
        this.damBar.UpdateBar(this.shootDam);
    }

    public virtual void AddShootPower(int power){
        this.shootPower += power;
        if(this.shootPower > this.shootPowerMax) this.shootPower = this.shootPowerMax;
        this.powerBar.UpdateBar(this.shootPower);

        this.shootDelay = 1f - this.shootPower * 0.15f;
    }
}
