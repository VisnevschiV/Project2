using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public weapon[] weapons;
    public int currentWeaponIndex;
    public Text amoDisplay;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<3;i++){
            weapons[i].Take();
            weapons[i].Reload();
            weapons[i].Hide();
        }
        weapons[0].Take();
        currentWeaponIndex=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1") && !weapons[0].isUsed){
            ChangeWeapon(0);
        }else if(Input.GetKeyDown("2") && !weapons[1].isUsed){
            ChangeWeapon(1);
        }else if(Input.GetKeyDown("3") && !weapons[2].isUsed){
            ChangeWeapon(2);
        }
        if(Time.time-weapons[currentWeaponIndex].lastReloadTime>weapons[currentWeaponIndex].reloadTime){
            weapons[currentWeaponIndex].Reload();
        }
        amoDisplay.text = weapons[currentWeaponIndex].amo.ToString();
    }

    void ChangeWeapon(int index){
        weapons[index].Take();
        weapons[currentWeaponIndex].Hide();
        currentWeaponIndex=index;
    }
    public void Shoot(){
        weapons[currentWeaponIndex].Shoot();
    }

}
