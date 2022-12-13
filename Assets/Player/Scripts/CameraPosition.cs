using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform cameraPosRight,cameraPosLeft;
    private bool isLeft, leftAvailable, rightAvailable;
    public LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        isLeft=true;
        leftAvailable=true;
        rightAvailable=true;
    }

    // Update is called once per frame
    void Update()
    {
        leftAvailable=!Physics.CheckSphere(cameraPosLeft.position, 1, ground);
        rightAvailable=!Physics.CheckSphere(cameraPosRight.position, 1, ground);
        if(Input.GetKeyDown("q")){
            if(isLeft && rightAvailable){
                MoveRight();
            }else if(!isLeft && leftAvailable){
                MoveLeft();
            }
        }
        if(isLeft && !leftAvailable){
            //MoveRight();
        }
        if(!isLeft && !rightAvailable){
            //MoveLeft();
        }
    }
    void MoveLeft(){
        transform.position=cameraPosLeft.position;
        isLeft=true;
    }
    void MoveRight(){
        transform.position=cameraPosRight.position;
        isLeft=false;
    }

   
    
}
