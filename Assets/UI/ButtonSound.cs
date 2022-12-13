using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource hoverSound, clickSound;
    
    // Start is called before the first frame update
    
    public void Hover(){
        hoverSound.Play(0);
    }

    public void Click(){
        clickSound.Play(0);
    }
}
