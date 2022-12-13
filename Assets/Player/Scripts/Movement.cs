using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 movedir;
    public Transform freeCam, aimCam;
    //jump
    Vector3 velocity;
    public float gravity=-9.81f;
    public float moveSpeed;
    public Transform groundCheck;
    public float groundDistance = 1.8f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight;
    public Aim aim;
    private float targetAngle;
    public Transform lookAtAim, lookAtFree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(Horizontal,0f,Vertical).normalized;
        
        if(aim.isAim){
            transform.LookAt(new Vector3(lookAtAim.position.x,transform.position.y,lookAtAim.position.z));
            targetAngle = Mathf.Atan2(direction.x, direction.z)* Mathf.Rad2Deg+aimCam.eulerAngles.y;
        }else{
            transform.LookAt(new Vector3(lookAtFree.position.x,transform.position.y,lookAtFree.position.z));
            targetAngle = Mathf.Atan2(direction.x, direction.z)* Mathf.Rad2Deg+freeCam.eulerAngles.y;
        }
        
        
        if(direction.magnitude >= 0.1f){
            movedir = Quaternion.Euler(0f,targetAngle,0f)*Vector3.forward;
            controller.Move(movedir*moveSpeed*Time.deltaTime);
        }
        //jump
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        if(isGrounded && velocity.y<0){
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump")&& isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y +=gravity *Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
    }
}
