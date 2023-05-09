using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorImpact : MonoBehaviour
{
    protected virtual void OnCollisionEnter2D(Collision2D other){
        if(!(other.collider.tag == "Player") || 
        other.transform.GetComponentInChildren<PlayerInventory>() == null || 
        other.transform.GetComponentInChildren<PlayerInventory>().HaveKey == false) 
        return;

        other.transform.GetComponentInChildren<PlayerInventory>().UseItem();
        transform.GetComponent<DoorManager>().OpenDoor();
    }
}
