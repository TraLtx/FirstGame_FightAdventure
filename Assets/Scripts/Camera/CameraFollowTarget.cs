using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : GameMonoBehaviour
{
    [SerializeField] protected Transform target;

    protected float smoothing = 0.5f;

    private Vector3 resetCamera;
    protected Vector2 maxPosition;
    protected Vector2 minPosition;

    protected override void LoadComponents(){
        base.LoadComponents();
    }

    protected override void Start(){
        resetCamera = Camera.main.transform.position;
        this.SetMoveRange(GameController.screenMinPoint, GameController.screenMaxPoint);
    }

    public virtual void SetTarget(Transform target){
        this.target = target;
    }

    protected virtual void SetMoveRange(Vector3 min, Vector3 max){
        float paddingX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0)).x - resetCamera.x;
        float paddingY = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height)).y - resetCamera.y;

        this.minPosition = new Vector2(min.x + paddingX, min.y + paddingY);
        this.maxPosition = new Vector2(max.x - paddingX, max.y - paddingY);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target == null || (transform.position.x == target.position.x && transform.position.y == target.position.y)) return;
        //if(transform.position.x != target.position.x || transform.position.y != target.position.y)
        //{
            // Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            Vector3 targetPosition = target.position;
            
            // targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            // targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
            // transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            // transform.position = new Vector3(targetPosition.x, targetPosition.y, -10);
            transform.position = new Vector3(
                Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x),
                Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y),
                -10
            );

            //Debug.Log("Camera: "+transform.position);
        //}
    }
}
