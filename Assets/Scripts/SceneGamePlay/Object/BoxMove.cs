using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : GameMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRidBody();
    }

    protected virtual void LoadRidBody(){
        if(this.rb != null) return;
        this.rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void OnCollisionExit2D(Collision2D other){
        if(!(other.collider.tag == "Player")) return;

        this.rb.velocity = new Vector2(0,0);
    }
}
