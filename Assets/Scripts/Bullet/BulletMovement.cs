using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : GameMonoBehaviour
{

    [SerializeField] private float bulletSpeed = 22f;
    [SerializeField] private Vector3 moveDirection;

    void Start(){
        this.moveDirection = Vector3.right;
    }

    // Start is called before the first frame update
    void Update()
    {
        transform.parent.Translate(this.moveDirection * this.bulletSpeed * Time.deltaTime);
    }
}
