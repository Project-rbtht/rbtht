using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour
{
    public int damage = 5;
    public float recastTime = 15;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null) {
                damageTarget.Damage(damage);
            }
        }
    }
}
