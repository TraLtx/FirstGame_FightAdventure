using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : GameMonoBehaviour
{
    [SerializeField] protected List<Transform> movePoints;
    [SerializeField] protected int speed = 2;
    [SerializeField] protected int currentIndexPoint = 0;

    [SerializeField] protected float stopTime = 1;
    [SerializeField] protected float delayTimer = 0;

    [SerializeField] protected Transform targetParent;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMovePoints();
    }
    protected virtual void LoadMovePoints(){
        Transform pointsHolder = transform.parent.Find("MovePoints");
        foreach (Transform point in pointsHolder)
        {
            movePoints.Add(point);
        }
    }
    protected virtual void FixedUpdate(){
        if(this.delayTimer < this.stopTime){
            this.delayTimer += Time.fixedDeltaTime;
            // Debug.Log("Stop: "+ this.delayTimer);
            return;
        }

        this.MoveFollowPoint();
    }

    protected virtual void MoveFollowPoint(){
        if(Vector2.Distance(this.movePoints[currentIndexPoint].position, transform.position) < 0.1f){
            this.delayTimer = 0;
            this.currentIndexPoint ++;
            if(this.currentIndexPoint >= this.movePoints.Count) this.currentIndexPoint = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position, movePoints[currentIndexPoint].position, Time.deltaTime * this.speed);
    }

    protected virtual void OnCollisionEnter2D(Collision2D other){
        if(!(other.collider.tag == "Player")) return;
        this.targetParent = other.transform.parent;
        other.transform.parent = transform;
        // other.gameObject.transform.SetParent(this.transform);
    }

    protected virtual void OnCollisionExit2D(Collision2D other){
        if(!(other.collider.tag == "Player")) return;
        other.transform.parent = this.targetParent;
        // other.gameObject.transform.SetParent(this.targetParent);
    }
}
