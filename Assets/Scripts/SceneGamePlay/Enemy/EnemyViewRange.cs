using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyViewRange : EnemyAbstract
{
    [SerializeField] protected float playerTransformDirection;
    public float PlayerTransformDirection => this.playerTransformDirection;
    
    protected void OnTriggerStay2D(Collider2D other){
        if(! (other.transform.tag == "Player")) return;//Debug.Log("See Player");

        this.playerTransformDirection = other.transform.position.x - transform.parent.position.x;

        enemyCtrl.IsSeePlayer = true;
    }

    protected void OnTriggerExit2D(Collider2D other){
        if(! (other.transform.tag == "Player")) return;

        enemyCtrl.IsSeePlayer = false;
    }
}
