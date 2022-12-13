using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alive : MonoBehaviour
{
    public int hp;
    public Slider hpBar;

    public void TakeDamage(int value, bool isPlayer){
        hp = hp-value;
        if(hp<1){
            Destroy(gameObject);
            if(!isPlayer){
                GameObject.Find("GameMaster").GetComponent<GameMaster>().EnemyKilled();
            }else{
                GameObject.Find("GameMaster").GetComponent<GameMaster>().GameLost();
            }
        }
    }
}
