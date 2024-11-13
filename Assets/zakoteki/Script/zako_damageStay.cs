using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zako_damageStay : MonoBehaviour
{
    public int damage=1;

    void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null) 
            {
                damageTarget.Damage(damage);
            }
        }
    }
}
