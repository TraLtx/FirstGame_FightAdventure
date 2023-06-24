using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.Move();
    }

    public virtual void Move(){
        this.transform.GetComponent<Rigidbody2D>().AddForce((new Vector2(transform.right.x, 1)) * 5f, ForceMode2D.Impulse);
    }

    // void FixedUpdate(){
    //     this.transform.GetComponent<Rigidbody2D>().AddForce(this.transform.right * 10f);
    // }
}
