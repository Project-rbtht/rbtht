using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zakobasicattack : MonoBehaviour, Idamagable
{
    public int ataerudamage = 1;
   
    public void Damage(int attackDamage) 
    {
       int damage = attackDamage;
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        

        if (collision.gameObject.tag == "Player") 
        {
            collision.gameObject.GetComponent<Idamagable>().Damage(ataerudamage);
        }

    }
}
