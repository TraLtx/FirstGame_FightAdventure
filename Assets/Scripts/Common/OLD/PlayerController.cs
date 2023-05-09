using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    public Rigidbody2D rb;

    private float moveSpeed;
    private float horizontalMove;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {Debug.Log(Input.GetAxis("Horizontal"));
        horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        animator.SetFloat("Horizontal", horizontalMove);
        // Debug.Log(horizontalMove);
        

        if(horizontalMove < 0){
            gameObject.transform.eulerAngles = new Vector3(0, -180, 0);
        }else if(horizontalMove > 0){
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        //Or somethings like that:
        // Copies another object's rotation
        // Quaternion objectRotation = otherObject.transform.rotation;
        // transform.rotation = objectRotation;
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + new Vector2(horizontalMove * moveSpeed * Time.fixedDeltaTime, 0));
    }
}
 