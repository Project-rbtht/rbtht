using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float speed = 0.1f;
    public int jpNumMax = 1;
    public float jpSpeed = 9.8f;
    public ground_judge groundJudge;
<<<<<<< HEAD
=======
    public GameObject[] attack = new GameObject[1];
    public int hp = 1;
    public float remainInvincibleTime = 1;
    public float justGardTime = 0.2f;
    public float justTimeStop = 0.2f;

    public int jpNum;
    public float[] counter;
>>>>>>> 0303008 (invincibility time after damaged)

    Rigidbody2D rb;
    int jpNum;
    Animator anim = null;
    float remainInvincible = 0;
    float guardTime = 0;
    bool guard = false;

    void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        jpNum = jpNumMax;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        //移動
        float x = Input.GetAxisRaw("Horizontal");
        float speedY = rb.velocity.y;

        if (Input.GetButton("Walk") == true) {
            x = x / 2;
        }

        if (speedY < 0 && anim.GetInteger("Jump") > 0) {
            anim.SetInteger("Jump", -1);
        }

        if (Input.GetButtonDown("Jump") == true) {
            if (groundJudge.onGround == true) {
                jpNum = jpNumMax;
            }
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

        //キャラクターの向き
        anim.SetInteger("Speed", (int)Mathf.Abs(x * 2));

        if (x != 0) {
            transform.localScale = new Vector3(x/Mathf.Abs(x), 1, 1);
        }

<<<<<<< HEAD
        Attacking("Attack", 1);

        void Attacking(string attackName, int damage) {
            if (Input.GetButtonDown(attackName)  == true) {
                anim.SetTrigger(attackName);
=======
        //攻撃
        for (int i = 0; i < attack.Length; i++) {
            if (Input.GetButtonDown("Attack" + i) == true && counter[i] == 0) {
                anim.SetTrigger("Attack" + i);
                counter[i] = attack[i].GetComponent<Attack>().recastTime;
            } else {
                counter[i] -= Time.deltaTime;
                if (counter[i] < 0) { counter[i] = 0; }
>>>>>>> 0303008 (invincibility time after damaged)
            }
        }

        //無敵時間
        if (remainInvincible > 0) {
            remainInvincible -= Time.deltaTime;
            if (remainInvincible <= 0) {
                anim.SetBool("Damaged", false);
                remainInvincible = 0;
            }
        }

        //ガード
        if (Input.GetButtonDown("Guard") == true) {
            guard = true;
        } else if (Input.GetButtonUp("Guard") == true) {
            guard = false;
            guardTime = 0;
        }

        if (guard) {
            guardTime += Time.deltaTime;
        }
    }
<<<<<<< HEAD
=======

    IEnumerator TimeStop(float time) {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(justTimeStop);
        Time.timeScale = 1;
    }

        public void Damage(int damage) {
        if (guardTime > justGardTime) {
            damage = (int)Math.Ceiling((float)damage / 2);
        }
        if (remainInvincible == 0 && (!guard || guardTime > justGardTime)) {
            hp -= damage;
            remainInvincible += remainInvincibleTime;
            anim.SetBool("Damaged", true);
            if (hp <= 0) {
                Debug.Log("GameOver");
            }
        }
        if (guard && guardTime <= justGardTime) {
            Debug.Log("Just!");
            StartCoroutine(TimeStop(justTimeStop));
        }
    }
>>>>>>> 0303008 (invincibility time after damaged)
}
