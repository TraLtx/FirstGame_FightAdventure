using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ThrowGrenade : GameMonoBehaviour
{
    [SerializeField] protected Transform shootingPoint;
    [SerializeField] protected int shootDam = 1;

    [SerializeField] protected float shootDelay = 3f;
    [SerializeField] protected float shootTimer = 3f;

    protected override void LoadComponents(){
        this.SetShootingPoint();
    }
    protected abstract void SetShootingPoint();
    protected abstract bool GetShootAble();

    protected abstract void ControlShootingPoint();

    protected virtual void FixedUpdate(){
        this.ControlShootingPoint();

        if(this.shootTimer < this.shootDelay){
            this.shootTimer += Time.fixedDeltaTime;

            return;
        }

        if(! this.GetShootAble()) return;
        this.Shoot();
    }

    protected virtual void Shoot(){
        // if(this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;
        // this.UpdateSlider();

        // Vector3 modelScale = transform.parent.localScale;

        // Quaternion rotation = new Quaternion(0,0,0,1);
        // if(modelScale.x < 1){
        //     rotation = new Quaternion(0,0,180,1);
        // }
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.grenade, this.shootingPoint.position, this.shootingPoint.rotation);
        if(newBullet == null){
            Debug.LogWarning("Can not Spawn Grenade");
            return;
        }
        newBullet.gameObject.SetActive(true);

        newBullet.GetComponent<GrenadeCtrl>().SetShooter(transform.parent);
        newBullet.GetComponent<GrenadeCtrl>().ResetBorn();
    }
}
