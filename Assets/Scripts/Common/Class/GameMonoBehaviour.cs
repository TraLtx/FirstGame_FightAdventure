using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMonoBehaviour : MonoBehaviour
{

    protected virtual void Awake()
    {
        // this.LoadComponents();
        // Debug.Log("Awake "+gameObject.name);
        this.Reset();
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void LoadComponents()
    {
        // For override
    }

    // protected virtual void Start(){
        
    // }

    protected virtual void ResetValue(){
    }

    protected virtual void OnEnable(){
        this.ResetValue();
    }

    protected virtual void OnDisable(){
    }
}
