using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : SpawnerWithPool
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance {get => instance;}

    protected override void Awake(){
        base.Awake();
        if(instance != null) return;
        instance = this;
    }

    public static string bulletOne = "Bullet_1";
    public static string bulletTwo = "Bullet_2";
    public static string bulletLaser = "Bullet_Laser";
}
