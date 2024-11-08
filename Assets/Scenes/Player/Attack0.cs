using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack0 : MonoBehaviour, Attack
{
    public int damage = 1;
    public float recastTime = 1;

    Animator playerAnim;

    void Start() {
        playerAnim = GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    void Update() {
        if(!playerAnim.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) {
            this.GameObject().SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Enemy") {
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null) {
                damageTarget.Damage(damage);
            }
        }
    }

    public float RecastTime() {
        return recastTime;
    }
}
