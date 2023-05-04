using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnerByTime : Despawner
{
    protected override bool IsDespawnAble(){
        return true;
    }
}
