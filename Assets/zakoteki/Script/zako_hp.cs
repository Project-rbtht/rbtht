using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zako_hp : MonoBehaviour,Idamagable
{
    public int hp = 2;
    public float recastTime = 1;
    public void Damage(int ukerudamage) 
    {
        hp -= ukerudamage;
        if (hp <= 0) {
            Debug.Log("hp = " + hp);
            Destroy(this.gameObject);
        }
    }
}
