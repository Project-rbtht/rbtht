using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zako_damageEnter : MonoBehaviour
{
    public int damage = 1;
    public float recastTime = 1;
    
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player")
         {
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null) 
            {
                damageTarget.Damage(damage);
            }
        }
        
    }
}
