using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : EnemyAbstract
{
    [SerializeField] protected float moveSpeed = 2;
    [SerializeField] protected float moveRange = 3;
    [SerializeField] protected float moveDistance = 0;
    [SerializeField] protected int horizontalMove = 1; //1 mean move to right
    [SerializeField] protected bool canTurn = true;

    [SerializeField] protected Vector3 thisSpawnPoint;
 
    protected virtual void Start(){
        this.thisSpawnPoint = transform.parent.position;
        this.SetUpRandomDirect();
    }
    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        if(enemyCtrl.IsDie) return;
        if(enemyCtrl.IsTouchEnemy){//Debug.Log("TouchEnemey TurnBack");
            this.canTurn = true;
            this.Redirect();
            enemyCtrl.IsTouchEnemy = false;
        }

        if(enemyCtrl.IsSeePlayer) {
            float playerDirect = enemyCtrl.EnemyViewRange.GetComponent<EnemyViewRange>().PlayerTransformDirection;
            // Debug.Log("playerDirect: "+playerDirect);
            // Debug.Log("horizontalMove * playerDirect: "+horizontalMove * playerDirect);
            if(horizontalMove * playerDirect < 0){//Debug.Log("Redirect");
                this.canTurn = true;
                this.Redirect();
            }

            enemyCtrl.CanShootPlayer = true;

            return;
        }else{
            enemyCtrl.CanShootPlayer = false;
        }

        // this.moveDistance = Vector3.Distance(transform.parent.position, enemyCtrl.ThisSpawnPoint.position);
        this.moveDistance = Vector3.Distance(transform.parent.position, this.thisSpawnPoint);

        if(moveDistance > moveRange){
            this.Redirect();
        }else{
            this.canTurn = true;
        }
        this.Move();
    }

    protected virtual void SetUpRandomDirect(){
        int random =  Random.Range(0, 2);
        if(random == 1) return;

        horizontalMove = -1;
        this.Flip();
    }

    protected virtual void Move(){
        Rigidbody2D rb = enemyCtrl._Rigidbody;
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);
    }

    protected virtual void Redirect(){
        if(!this.canTurn) return;

        horizontalMove *= -1;
        this.Flip();
        this.canTurn = false;
    }

    private void Flip()
    {
        transform.parent.Rotate(0f, 180f, 0f);

        // Vector3 localScale = transform.parent.localScale;
        // localScale.x *= -1f;
        // transform.parent.localScale = localScale;
    }
}
