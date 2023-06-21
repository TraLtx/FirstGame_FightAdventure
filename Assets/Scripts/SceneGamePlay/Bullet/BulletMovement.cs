using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : BulletAbstract
{

    [SerializeField] protected float bulletSpeed = 40f;
    [SerializeField] protected Vector3 moveDirection;

    protected virtual void Start(){
        this.moveDirection = Vector3.right;
    }

    // Start is called before the first frame update
    protected virtual void FixedUpdate()
    {
        if(! this.bulletCtrl.GetMoveAble()) return;
        transform.parent.Translate(this.moveDirection * this.bulletSpeed * Time.deltaTime);
    }
}
