using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public GameObject model, bullet;
    public bool isUsed,canAttack;
    public int dmg, amo, reloadValue;
    public float timeBetweenAttacks, reloadTime, lastReloadTime;
    public Transform bulletStartPos;
    public Aim aim;

    
    public void Shoot(){
        //Instantiate(bullet,bulletStartPos.position,Quaternion.Euler(0,0,0));
        if(canAttack){
            if(Physics.CheckSphere(aim.focus.transform.position, 1, aim.enemy)){
                if(dmg<50){
                    Physics.OverlapSphere(aim.focus.transform.position, 1, aim.enemy)[0].gameObject.transform.GetComponent<Alive>().TakeDamage(dmg,false);
                }
            }
            if(Physics.CheckSphere(aim.focus.transform.position, 1, aim.ground)){
                Debug.Log("Ground");
                if(dmg>50){
                    Debug.Log("bomb");
                    Instantiate(bullet, aim.focus.transform.position, Quaternion.identity);
                }
            }
            transform.GetComponent<AudioSource>().Play(0);
            canAttack=false;
            Invoke(nameof(ReadyToShoot),timeBetweenAttacks);
            amo--;
        }
    }
    public void Take(){
        canAttack=true;
        model.SetActive(true);
        isUsed=true;
    }
    private void ReadyToShoot(){
        canAttack=true;
    }
    public void Hide(){
        model.SetActive(false);
        isUsed=false;
    }
   public void Reload(){
        amo= amo+reloadValue;
        lastReloadTime=Time.time;
    }
}
