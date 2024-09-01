using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour, Idamagable {

    public float speed = 0.1f;
    public int jpNumMax = 1;
    public float jpSpeed = 9.8f;
    public GroundJudge groundJudge;
    public GameObject[] attack = new GameObject[1];
    public int maxHP = 1;
    public float remainInvincibleTime = 1;
    public float justGuardTiming = 0.2f;
    public float justTimeStop = 0.2f;
    public ShieldScript shieldScript;
    public float shieldHP = 1;
    public float shieldDecTime = 5;
    public float shieldRechargeTime = 1;
    public GameObject healthBar;
    public GameObject healthTriangle;
    public GameObject damagedBar;
    public GameObject damagedTriangle;
    public GameObject currentEnergyBar;
    public GameObject currentEnergyTriangle;

    public int jpNum;
    public float[] counter;

    Rigidbody2D rb;
    Animator anim = null;
    float remainInvincible = 0;
    bool guard = false;
    GameObject shield = null;
    float shieldHPCur = 0;
    float justGuardTime = 0;
    float shieldRecharge = 0;
    int hp;

    void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        jpNum = jpNumMax;
        anim = GetComponent<Animator>();
        counter = new float[attack.Length];
        Array.Fill<float>(counter, 0);
        shieldHPCur = shieldHP;
        hp = maxHP;
    }

    // Update is called once per frame
    void Update() {
        //à⁄ìÆ
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

        //ÉLÉÉÉâÉNÉ^Å[ÇÃå¸Ç´
        anim.SetInteger("Speed", (int)Mathf.Abs(x * 2));

        if (x != 0) {
            transform.localScale = new Vector3(x/Mathf.Abs(x), 1, 1);
        }

        //çUåÇ
        for (int i = 0; i < attack.Length; i++) {
            if (Input.GetButtonDown("Attack" + i) == true && counter[i] == 0) {
                anim.SetTrigger("Attack" + i);
                counter[i] = attack[i].GetComponent<Attack>().recastTime;
            } else {
                counter[i] -= Time.deltaTime;
                if (counter[i] < 0) { counter[i] = 0; }
            }
        }

        //ñ≥ìGéûä‘
        if (remainInvincible > 0) {
            remainInvincible -= Time.deltaTime;
            if (remainInvincible <= 0) {
                anim.SetBool("Damaged", false);
                remainInvincible = 0;
            }
        }

        //ÉKÅ[Éh
        if (guard) {
            if (Input.GetButtonUp("Guard") == true) {
                guard = false;
                shieldScript.gameObject.SetActive(false);
                justGuardTime = justGuardTiming;
            }
            shieldHPCur -= Time.deltaTime / shieldDecTime * shieldHP;
            if (shieldHPCur <= 0) {
                shieldHPCur = 0;
                guard = false;
                shieldScript.gameObject.SetActive(false);
                shieldRecharge = shieldRechargeTime;
                remainInvincible = remainInvincibleTime / 10;
            }
        } else {
            if (Input.GetButton("Guard") == true && justGuardTime == 0 && shieldRecharge == 0) {
                guard = true;
                shieldScript.gameObject.SetActive(true);
                shieldHPCur = shieldHP;
            }
            if (shieldRecharge > 0) {
                shieldRecharge -= Time.deltaTime;
                if (shieldRecharge < 0) {
                    shieldRecharge = 0;
                }
            }
            if (shieldHPCur != shieldHP) {
                shieldHPCur += Time.deltaTime / shieldRechargeTime * shieldHP;
                if (shieldHPCur > shieldHP) {
                    shieldHPCur = shieldHP;
                }
            }
            if (justGuardTime != 0) {
                justGuardTime -= Time.deltaTime;
                if (justGuardTime < 0) {
                    justGuardTime = 0;
                }
            }
        }
        currentEnergyBar.GetComponent<Image>().fillAmount = shieldHPCur / shieldHP;
        Vector3 eneTriPos = currentEnergyTriangle.transform.localPosition;
        currentEnergyTriangle.transform.localPosition = new Vector3((shieldHPCur / shieldHP - 0.5f) * currentEnergyBar.GetComponent<RectTransform>().sizeDelta.x - currentEnergyTriangle.GetComponent<RectTransform>().sizeDelta.x / 2, eneTriPos.y, 0);
    }

    IEnumerator TimeStop(float time) {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(justTimeStop);
        Time.timeScale = 1;
    }

    public void Damage(int damage) {
        if (guard) {
            shieldHPCur -= damage;
            if (shieldHPCur <= 0) {
                shieldRecharge = shieldRechargeTime;
                guard = false;
                shieldScript.gameObject.SetActive(false);
                remainInvincible = remainInvincibleTime / 10;
            }
        }
        if (remainInvincible == 0 && !guard && justGuardTime == 0) {
            hp -= damage;
            remainInvincible += remainInvincibleTime;
            anim.SetBool("Damaged", true);
            if (hp <= 0) {
                Debug.Log("GameOver");
            }
            healthBar.GetComponent<Image>().fillAmount = (float)hp / (float)maxHP;
            Vector3 triPos = healthTriangle.transform.localPosition;
            healthTriangle.transform.localPosition = new Vector3(triPos.x - damage / (float)maxHP * healthBar.GetComponent<RectTransform>().sizeDelta.x , triPos.y, 0);
        }
        if (justGuardTime > 0) {
            StartCoroutine(TimeStop(justTimeStop));
            remainInvincible = remainInvincibleTime / 2;
        }
    }
}
