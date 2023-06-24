using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCtrl : GameMonoBehaviour
{
    [SerializeField] protected DamSender damSender;
    public DamSender DamSender => this.damSender;
    [SerializeField] protected GrenadeScopeImpact scopeImpact;

    [SerializeField] protected float countDownTime = 3f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamSender();
        this.LoadScopeImpact();

    }

    protected virtual void LoadDamSender(){
        if(this.damSender != null) return;
        this.damSender = GetComponentInChildren<DamSender>();
    }
    protected virtual void LoadScopeImpact(){
        if(this.scopeImpact != null) return;
        this.scopeImpact = GetComponentInChildren<GrenadeScopeImpact>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.Countdown());
    }
    public virtual void ResetBorn(){
        GetComponent<GrenadeMovement>().Move();
        this.scopeImpact.DeactiveScope();
        StartCoroutine(this.Countdown());
    }

    protected virtual IEnumerator Countdown(){Debug.Log("Countdown");
        yield return new WaitForSeconds(countDownTime);
        StartCoroutine(this.Boom());
    }

    protected virtual IEnumerator Boom(){Debug.Log("Boom");
        Transform fx_impact = AnimationSpawner.Instance.Spawn(AnimationSpawner.grenadeBoom, transform.position, Quaternion.identity);
        fx_impact.gameObject.SetActive(true);
        this.scopeImpact.ActiveScope();
        
        yield return new WaitForSeconds(Time.fixedDeltaTime);
        this.BackToPool();
    }

    protected virtual void BackToPool(){Debug.Log("BackToPool");
        BulletSpawner.Instance.BackObjToPool(transform);
    }



}
