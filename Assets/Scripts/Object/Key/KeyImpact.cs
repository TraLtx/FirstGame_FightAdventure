using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyImpact : GameMonoBehaviour
{
   protected void OnTriggerEnter2D(Collider2D other){
      if ( !(other.tag == "Player") ) return;

      PlayerInventory playerInventory = other.transform.GetComponentInChildren<PlayerInventory>();
      if(playerInventory == null) return;

      playerInventory.StoreItem();
       
      Destroy(transform.gameObject);
   }
}
