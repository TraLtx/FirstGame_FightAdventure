using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;


public class PassLevelPoint : MonoBehaviour
{
    [SerializeField] public GameObject pannel;

    protected virtual void OnCollisionEnter2D(Collision2D other){
        if(!(other.collider.tag == "Player")) return;

        this.pannel.SetActive(true);
        Time.timeScale = 0;
    }
}
