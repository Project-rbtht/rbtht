using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack0 : MonoBehaviour, Attack
{
    public int damage = 1;
    public float recastTime = 1;

    GameObject player;
    Animator playerAnim;

    void Start() {
        player = GameObject.FindWithTag("Player");
        playerAnim = player.GetComponent<Animator>();
    }

    void Update() {
        if(!playerAnim.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) {
            this.GameObject().SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null) {
                damageTarget.Damage(damage);
                player.GetComponent<PlayerScript>().Hit();
            }
        }
    }

    public float RecastTime() {
        return recastTime;
    }
}
