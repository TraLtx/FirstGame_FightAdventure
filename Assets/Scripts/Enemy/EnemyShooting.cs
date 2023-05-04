using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : EnemyAbstract
{
    [SerializeField] private float shootDelay = 0.5f;
    [SerializeField] private float shootTimer = 0f;

    // Update is called once per frame
    protected virtual void Update()
    {
        if(!enemyCtrl.IsSeePlayer) return;

        this.Shoot();
    }

    protected virtual void Shoot(){
        if(this.shootTimer < this.shootDelay) this.shootTimer += Time.deltaTime;

        if(this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0;

        Vector3 modelScale = transform.parent.localScale;

        Quaternion rotation = new Quaternion(0,0,0,1);
        if(modelScale.x < 1){
            rotation = new Quaternion(0,0,180,1);
        }
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, enemyCtrl.EnemyShootingPoint.position, rotation);
        if(newBullet == null){
            Debug.LogWarning("Can not Spawn Bullet");
            return;
        }
        newBullet.gameObject.SetActive(true);
        newBullet.GetComponent<BulletCtrl>().SetShooter(transform.parent);
    }
}
