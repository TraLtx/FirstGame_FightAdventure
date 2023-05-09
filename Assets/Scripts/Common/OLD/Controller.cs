using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : GameMonoBehaviour
{
    protected static Controller instance;
    public static Controller Instance {get => instance;}
}
