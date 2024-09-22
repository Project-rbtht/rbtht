using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zakohpdamageable: MonoBehaviour, Idamagable
{
    public int hp = 1;
    public int damage = 0;
    public float recastTime = 1;

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null) 
            {
                damageTarget.Damage(damage);
            }
        }
    }
 
    public void Damage(int ukerudamage) 
    {
        hp -= ukerudamage;
        if (hp <= 0) {
            Debug.Log("hp = " + hp);
            Destroy(this.gameObject);
        }
    }


}
