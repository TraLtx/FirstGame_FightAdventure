using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCtrl : GameMonoBehaviour
{
    [SerializeField] protected Transform shooter;
    public Transform Shooter{get => this.shooter;}

    [SerializeField] protected DamSender damSender;
    public DamSender DamSender => this.damSender;
    [SerializeField] protected GrenadeScopeImpact scopeImpact;

    [SerializeField] protected float countDownTime = 3f;
    [SerializeField] protected float timer = 0f;

    [SerializeField] protected Collider2D _collider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamSender();
        this.LoadScopeImpact();
        this.LoadCollider();
    }

    protected virtual void LoadDamSender(){
        if(this.damSender != null) return;
        this.damSender = GetComponentInChildren<DamSender>();
    }
    protected virtual void LoadScopeImpact(){
        if(this.scopeImpact != null) return;
        this.scopeImpact = GetComponentInChildren<GrenadeScopeImpact>();
    }
    protected virtual void LoadCollider(){
        if(this._collider != null) return;
        this._collider = GetComponentInChildren<Collider2D>();
    }
    // Start is called before the first frame update
    // void Start()
    // {
    //     StartCoroutine(this.Countdown());
    // }

    protected virtual void FixedUpdate(){
        if(this.timer < this.countDownTime){
            this.timer += Time.fixedDeltaTime;

            return;
        }

        this.Boom();
    }
    public virtual void ResetBorn(){
        GetComponent<GrenadeMovement>().Move();
        this.scopeImpact.DeactiveScope();
        this.timer = 0;
        // StartCoroutine(this.Countdown());
    }

    public virtual void SetShooter(Transform shooter){
        this.shooter = shooter;
    }

    // protected virtual void Countdown(){
    //     yield return new WaitForSeconds(countDownTime);
    //     StartCoroutine(this.Boom());
    // }

    public virtual void Boom(){Debug.Log("BOOOM!!");
        Transform fx_impact = AnimationSpawner.Instance.Spawn(AnimationSpawner.grenadeBoom, transform.position, Quaternion.identity);
        fx_impact.gameObject.SetActive(true);
        this.scopeImpact.ActiveScope();
        
        // yield return new WaitForSeconds(Time.fixedDeltaTime);
        // this.BackToPool();
        StartCoroutine(this.TurnOff());
    }

    protected virtual IEnumerator TurnOff(){
        
        yield return new WaitForSeconds(Time.fixedDeltaTime);

        this.BackToPool();
    }

    protected virtual void BackToPool(){
        BulletSpawner.Instance.BackObjToPool(transform);
    }

    protected virtual void OnCollisionEnter2D(Collision2D other){
        if(other.collider.tag != "Player") return;

        this.Boom();
    }

}
