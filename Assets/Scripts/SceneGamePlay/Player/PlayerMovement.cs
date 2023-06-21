using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : PlayerAbstract
{
    [SerializeField] protected float speed = 8f;
    [SerializeField] protected float jumpingPower = 16f;
    [SerializeField] protected float horizontalMove;
    [SerializeField] protected bool isFacingRight = true;
    [SerializeField] protected bool isStop = true;

    [SerializeField] protected LayerMask groundLayer;
    [SerializeField] protected Rigidbody2D rb;

    [SerializeField] protected Vector2 minMoveRange;
    [SerializeField] protected Vector2 maxMoveRange;

    protected override void ResetValue(){
        this.SetRigidbodyTarget();
        this.SetLayerGround();
    }
    
    protected virtual void SetRigidbodyTarget(){
        if(this.rb != null) return;
        this.rb = playerCtrl._Rigidbody;
    }

    protected void SetLayerGround(){
        if(groundLayer == LayerMask.GetMask("Ground")) return;
        groundLayer = LayerMask.GetMask("Ground");
    }

    protected virtual void SetMoveRange(Vector3 min, Vector3 max){
        float padding = playerCtrl.SpriteRenderer.bounds.size.x / 2;

        this.minMoveRange = new Vector2(min.x + padding, min.y + padding);
        this.maxMoveRange = new Vector2(max.x - padding, max.y - padding);
    }

    protected override void Start(){
        this.SetMoveRange(GameController.screenMinPoint, GameController.screenMaxPoint);
    }

    void FixedUpdate()
    {
        if(GameController.Instance.IsOnlineState && !playerCtrl.View.IsMine) return;

        horizontalMove = InputManager.Instance.GetMoveStatus();

        if (InputManager.Instance.GetJumpStatus() && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if(rb.velocity.y != 0){
            this.CheckValidMove();
        }

        if(horizontalMove != 0) isStop = false;
        if(isStop) return;
        this.Move();
        if(horizontalMove == 0) isStop = true;
    }

    protected virtual void Move(){
        Flip();
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        this.CheckValidMove();
    }

    protected bool IsGrounded()
    {
        return Physics2D.OverlapCircle(playerCtrl.GroundCheck.position, 0.2f, groundLayer);
    }

    protected void Flip()
    {
        if (isFacingRight && horizontalMove < 0f || !isFacingRight && horizontalMove > 0f)
        {
            isFacingRight = !isFacingRight;

            transform.parent.Rotate(0f, 180f, 0f);
            // Vector3 localScale = transform.parent.localScale;
            // localScale.x *= -1f;
            // transform.parent.localScale = localScale;
        }
    }

    protected virtual void CheckValidMove(){
        if(transform.parent.position.y > maxMoveRange.y) rb.velocity = new Vector2(rb.velocity.x, 0);

        transform.parent.position = new Vector3(
                Mathf.Clamp(transform.parent.position.x, minMoveRange.x, maxMoveRange.x),
                Mathf.Clamp(transform.parent.position.y, minMoveRange.y, maxMoveRange.y),
                0
            );
    }

}
