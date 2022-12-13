using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage;
    public LayerMask enemy;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Boom),2);
      
    }
    void Boom(){
         Collider[] enemies = Physics.OverlapSphere(transform.position, 20, enemy);

        for(int i=0; i<enemies.Length;i++){
            enemies[i].gameObject.transform.GetComponent<Alive>().TakeDamage(80,false);
        }
        Destroy(gameObject);
    }
}
