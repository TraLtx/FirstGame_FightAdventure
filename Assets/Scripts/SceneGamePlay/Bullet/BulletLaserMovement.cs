using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLaserMovement : BulletMovement
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        this.bulletSpeed = 60f;
    }

}
