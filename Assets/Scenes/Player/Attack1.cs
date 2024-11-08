using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack1 : MonoBehaviour, Attack
{
    public int damage = 5;
    public float recastTime = 15;
    public GroundJudge groundJudge;

    GameObject player;
    Animator playerAnim;
    void OnEnable() {
        if (player == null) {
            player = GameObject.FindWithTag("Player");
            playerAnim = player.GetComponent<Animator>();
        }
        player.GetComponent<PlayerScript>().canMove = false;
    }

    void OnDisable() {
        player.GetComponent<PlayerScript>().canMove = true;
        if (!groundJudge.onGround) {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player.GetComponent<PlayerScript>().jpSpeed / 2);
        }
    }

    void Update() {
        if (!playerAnim.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) {
            this.gameObject.SetActive(false);
        }
    }

    void LateUpdate() {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    void OnTriggerEnter2D(Collider2D collision) {
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