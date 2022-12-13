using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Aim : MonoBehaviour
{
    public Camera freeCam, aimCam;
    public GameObject focus;
    private Ray ray;

    public bool isAim;
    public LayerMask enemy,ground;

    // Start is called before the first frame update
    void Start(){
        isAim=false;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 centerCamera = new Vector2(Screen.width/2f, Screen.height/2f);
        if(isAim){
            ray = aimCam.ScreenPointToRay(centerCamera);
        }else{
            ray = freeCam.ScreenPointToRay(centerCamera);
        }
        if(Physics.Raycast(ray, out RaycastHit raycastHit)){
            focus.transform.position = raycastHit.point;
            //raycastHit.transform.GetComponent<Alive>().TakeDamage(10,false);
        }


        if(Input.GetMouseButtonDown(1)){
            SetAim();
        }
    }

    private void SetAim(){
        if(isAim){
                freeCam.transform.position=aimCam.transform.position;
                freeCam.gameObject.SetActive(true);
                aimCam.gameObject.SetActive(false);
                isAim= !isAim;
            }else{
                aimCam.transform.position=freeCam.transform.position;
                freeCam.gameObject.SetActive(false);
                aimCam.gameObject.SetActive(true);
                isAim= !isAim;
            }
    }
}
