using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Alive
{
    public Inventory inventory;
    
    // Start is called before the first frame update
    void Start()
    {
        hp=100;
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.value=hp;
        if(Input.GetMouseButtonDown(0)){
            Shoot();
        }
    }

    void Shoot(){
        inventory.Shoot();
    }
}
