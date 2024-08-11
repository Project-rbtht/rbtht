using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float speed = 0.1f;
    public int jpNumMax = 1;
    public float jpSpeed = 9.8f;
    public ground_judge groundJudge;

    Rigidbody2D rb;
    public int jpNum;
    Animator anim = null;

    void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        jpNum = jpNumMax;
        anim = GetComponent<Animator>();
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

        Attacking("Attack", 1);

        void Attacking(string attackName, int damage) {
            if (Input.GetButtonDown(attackName)  == true) {
                anim.SetTrigger(attackName);
            }
        }
    }
}
