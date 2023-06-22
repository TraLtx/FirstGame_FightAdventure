using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXBulletImpact : GameMonoBehaviour
{
    // [SerializeField] 
    // Start is called before the first frame update

    public virtual void OnComplete(){
        AnimationSpawner.Instance.BackObjToPool(transform);
    }

}
