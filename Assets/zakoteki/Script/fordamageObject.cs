using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fordamageObject : MonoBehaviour, Idamagable
{
    public int hp = 2;
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
 
    public void Damage(int ukerudamage) 
    {
        hp -= ukerudamage;
        if (hp <= 0) {
            Debug.Log("hp = " + hp);
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }


}