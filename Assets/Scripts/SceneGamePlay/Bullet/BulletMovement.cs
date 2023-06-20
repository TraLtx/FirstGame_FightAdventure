using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : BulletAbstract
{

    [SerializeField] private float bulletSpeed = 30f;
    [SerializeField] private Vector3 moveDirection;

    void Start(){
        this.moveDirection = Vector3.right;
    }

    // Start is called before the first frame update
    void FixedUpdate()
    {
        if(! this.bulletCtrl.GetMoveAble()) return;
        transform.parent.Translate(this.moveDirection * this.bulletSpeed * Time.deltaTime);
    }
}
