using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassLevelPoint : GameMonoBehaviour
{
    protected virtual void OnCollisionEnter2D(Collision2D other){
        if(!(other.collider.tag == "Player")) return;

        GameController.Instance.PassLevel();
    }
}
