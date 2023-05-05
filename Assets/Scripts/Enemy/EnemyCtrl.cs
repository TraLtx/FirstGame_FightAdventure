using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : GameMonoBehaviour
{
    //---Component------------------------------------------------------------------
    [SerializeField] protected Rigidbody2D _rigidbody;
    public Rigidbody2D _Rigidbody => this._rigidbody;

    //---Child----------------------------------------------------------------------
    [SerializeField] protected Transform enemyShootingPoint;
    public Transform EnemyShootingPoint => this.enemyShootingPoint;

    [SerializeField] protected Transform enemyViewRange;
    public Transform EnemyViewRange => this.enemyViewRange;

    [SerializeField] protected Transform animation;

    //---Variable-------------------------------------------------------------------
    [SerializeField] protected Transform thisSpawnPoint;
    public Transform ThisSpawnPoint => this.thisSpawnPoint;
    
    [SerializeField] protected bool isSeePlayer = false;
    public bool IsSeePlayer {set => this.isSeePlayer = value; get => this.isSeePlayer;}

    [SerializeField] protected bool isTouchEnemy = false;
    public bool IsTouchEnemy {set => this.isTouchEnemy = value; get => this.isTouchEnemy;}

    [SerializeField] protected bool isDie = false;
    public bool IsDie {get => this.isDie;}

    //------------------Load Components--------------------
    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadRigidbody();
        this.LoadEnemyShootingPoint();
        this.LoadEnemyViewRange();
        this.LoadAnimation();
    }

    protected virtual void LoadRigidbody(){
        if(this._rigidbody != null) return;

        this._rigidbody = GetComponent<Rigidbody2D>();
    }
    
    protected virtual void LoadEnemyShootingPoint(){
        if(this.enemyShootingPoint != null) return;

        this.enemyShootingPoint = transform.Find("ShootingPoint");
    }

    protected virtual void LoadEnemyViewRange(){
        if(this.enemyViewRange != null) return;

        this.enemyViewRange = transform.Find("ViewRange");
    }

    protected virtual void LoadAnimation(){
        if(this.animation != null) return;
        this.animation = transform.Find("EnemyAnimation");
    }
    //-----------------------------------------------------

    public virtual void SetThisSpawnPoint(Transform spawnPoint){
        this.thisSpawnPoint = spawnPoint;
    }

    public virtual void Die(){
        this.isDie = true;
        this.animation.GetComponent<EnemyAnimation>().TurnOnDieAnimation();
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
