using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSpawner : SpawnerWithPool
{
    private static AnimationSpawner instance;
    public static AnimationSpawner Instance {get => instance;}

    protected override void Awake(){
        base.Awake();
        if(instance != null) return;
        instance = this;
    }
    public static string bulletImpact = "Effect_BulletImpact";
    public static string grenadeBoom = "Effect_GrenadeBoom";
}
