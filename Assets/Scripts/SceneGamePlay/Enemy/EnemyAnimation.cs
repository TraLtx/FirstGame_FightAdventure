using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : EnemyAbstract
{
    [SerializeField] protected Animator animator;

    protected override void LoadComponents(){
        base.LoadComponents();
        this.LoadAnimator();
    }

    protected virtual void LoadAnimator(){
        if(this.animator != null) return;
        this.animator = GetComponent<Animator>();
    }

    public virtual void TurnOnDieAnimation(){
        transform.GetComponent<Animator>().SetTrigger("Die");
    }

    public virtual void DieAnimationDone(){
        Destroy(transform.gameObject);
        Transform newCoin = CoinSpawner.Instance.Spawn(CoinSpawner.silverCoin, transform.position, transform.rotation);
        newCoin.gameObject.SetActive(true);
    }
}
