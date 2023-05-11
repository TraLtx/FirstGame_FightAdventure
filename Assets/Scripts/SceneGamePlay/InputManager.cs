using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private static InputManager instance;
    public static InputManager Instance {get => instance;} 

    private bool isBtnRunLeft = false;
    private bool isBtnRunRight = false;
    private bool isBtnJump = false;
    private bool isBtnFight = false;
    private bool isUlti = false;

    void Awake()
    {
        if(instance != null) return;
        instance = this;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) isBtnRunRight = true;
        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) isBtnRunRight = false;

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) isBtnRunLeft = true;
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) isBtnRunLeft = false;
        
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) isBtnJump = true;
        if(Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.Space)|| Input.GetKeyUp(KeyCode.UpArrow)) isBtnJump = false;

        
        if(Input.GetKeyDown(KeyCode.J)) isBtnFight = true;
        if(Input.GetKeyUp(KeyCode.J)) isBtnFight = false;

        if(Input.GetKeyDown(KeyCode.K)) isUlti = true;
        if(Input.GetKeyUp(KeyCode.K)) isUlti = false;
    }

    

    public int GetMoveStatus(){
        if(!isBtnRunLeft && !isBtnRunRight){
            return 0;
        }else{
            return (isBtnRunRight)? (1) : (-1);
        }

    }

    public bool GetJumpStatus(){
        return isBtnJump;
    }

    public bool GetFightStatus(){
        return isBtnFight;
    }

    public bool GetUltiStatus(){
        return isUlti;
    }

    //-------------------------------------------

    public void ClickBtnRunLeft(){
        Debug.Log("ClickBtnRunLeft");
        isBtnRunLeft = true;
    }

    public void ClickBtnRunRight(){
        isBtnRunRight = true;
    }

    public void ClickBtnJump(){
        isBtnJump = true;
    }

    public void ClickBtnFight(){
        isBtnFight = true;
    }

    //---------------------------------------------

    public void OutClickBtnRunLeft(){
        isBtnRunLeft = false;
    }

    public void OutClickBtnRunRight(){
        isBtnRunRight = false;
    }

    public void OutClickBtnJump(){
        isBtnJump = false;
    }

    public void OutClickBtnFight(){
        isBtnFight = false;
    }
}
