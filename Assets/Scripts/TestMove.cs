using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 15f;
    [SerializeField] private float horizontalMove;

    [SerializeField] private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = InputManager.Instance.GetMoveStatus();

        if (InputManager.Instance.GetJumpStatus())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
    }
}
