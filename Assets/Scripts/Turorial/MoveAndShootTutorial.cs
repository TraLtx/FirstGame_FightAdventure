using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndShootTutorial : Tutorial
{
    protected override void SetTutorialContent(){
        this.tutorialContent = "Arrow keys to Move. J key to shoot!";
    }

    protected override void SetShowTime(){
        this.showTime = 5;
    }
}
