using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerScript : MonoBehaviour, Idamagable {

    public float speed = 0.1f;
    public int jpNumMax = 1;
    public float jpSpeed = 9.8f;
    public ground_judge groundJudge;
    public GameObject[] attack = new GameObject[1];
    public int hp = 1;

    public int jpNum;
    public float[] counter;

    Rigidbody2D rb;
    Animator anim = null;

    void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        jpNum = jpNumMax;
        anim = GetComponent<Animator>();
        counter = new float[attack.Length];
        Array.Fill<float>(counter, 0);
    }

    // Update is called once per frame
    void Update() {

        float x = Input.GetAxisRaw("Horizontal");
        float speedY = rb.velocity.y;

        if (Input.GetButton("Walk") == true) {
            x = x / 2;
        }

        if (speedY < 0 && anim.GetInteger("Jump") > 0) {
            anim.SetInteger("Jump", -1);
        }

        if (Input.GetButtonDown("Jump") == true) {
            if (jpNum > 0) {
                speedY = jpSpeed;
                if (groundJudge.onGround == true) {
                    anim.SetInteger("Jump", 1);
                }else{
                    anim.SetInteger("Jump", 2);
                }
                jpNum--;
            }
        }

        rb.velocity = new Vector2(x * speed, speedY);

        anim.SetInteger("Speed", (int)Mathf.Abs(x * 2));
        if (x != 0) {
            transform.localScale = new Vector3(x/Mathf.Abs(x), 1, 1);
        }

        for (int i = 0; i < attack.Length; i++) {
            if (Input.GetButtonDown("Attack" + i) == true && counter[i] == 0) {
                anim.SetTrigger("Attack" + i);
                counter[i] = attack[i].GetComponent<Attack>().recastTime;
            } else {
                counter[i] -= Time.deltaTime;
                if (counter[i] < 0) { counter[i] = 0; }
            }
        }
    }

    public void Damage(int damage) {
        hp -= damage;
        if (hp <= 0) {
            Debug.Log("GameOver");
        }
    }
}
