using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour, Idamagable
{
    public int hp = 1;
    public void Damage(int damage) {
        hp -= damage;
        if (hp <= 0) {
            Debug.Log("hp = " + hp);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Idamagable>().Damage(1);
        }
    }
}
