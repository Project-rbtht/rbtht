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
    public float gravityScale = 1;
    public GroundJudge groundJudge;
    public GameObject[] attack = new GameObject[1];
    public int maxHP = 1;
    public float remainInvincibleTime = 1;
    public float justGuardTiming = 0.2f;
    public float justTimeStop = 0.2f;
    public ShieldScript shieldScript;
    public float energyHP = 1;
    public float shieldDecTime = 5;
    public float energyRechargeTime = 1;
    public GameObject healthBar;
    public GameObject healthTriangle;
    public GameObject damagedBar;
    public GameObject damagedTriangle;
    public GameObject currentEnergyBar;
    public GameObject currentEnergyTriangle;
    public float energyHealing = 0.5f; // energyHP / damage
    public float energyMaxHealing = 2f;
    public float deathTimeStop = 0.5f;
    public GameOver gameOver;

    public int jpNum;
    public float[] counter;

    Rigidbody2D rb;
    Animator anim = null;
    float remainInvincible = 0;
    bool guard = false;
    GameObject shield = null;
    float energyHPCur = 0;
    float justGuardTime = 0;
    bool shieldRecharge = false;
    int hp;

    void Start () {
        rb = this.GetComponent<Rigidbody2D>();
        jpNum = jpNumMax;
        anim = GetComponent<Animator>();
        counter = new float[attack.Length];
        Array.Fill<float>(counter, 0);
        energyHPCur = energyHP;
        hp = maxHP;
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

        //重力
        if (!groundJudge.onGround) {
            rb.AddForce(new Vector2(0, -5f * gravityScale));
        }

            //キャラクターの向き
            anim.SetInteger("Speed", (int)Mathf.Abs(x * 2));

        if (x != 0) {
            transform.localScale = new Vector3(x/Mathf.Abs(x), 1, 1);
        }

        //攻撃
        for (int i = 0; i < attack.Length; i++) {
            if (Input.GetButtonDown("Attack" + i) == true && counter[i] == 0) {
                anim.SetTrigger("Attack" + i);
                counter[i] = attack[i].GetComponent<Attack>().recastTime;
            } else {
                counter[i] -= Time.deltaTime;
                if (counter[i] < 0) { counter[i] = 0; }
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
        if (guard) {
            if (Input.GetButtonUp("Guard") == true) {
                guard = false;
                shieldScript.gameObject.SetActive(false);
                justGuardTime = justGuardTiming;
            }
            energyHPCur -= Time.deltaTime / shieldDecTime * energyHP;
            if (energyHPCur <= 0) {
                energyHPCur = 0;
                guard = false;
                shieldScript.gameObject.SetActive(false);
                shieldRecharge = true;
                remainInvincible = remainInvincibleTime / 10;
            }
        } else {
            if (Input.GetButton("Guard") == true && justGuardTime == 0 && !shieldRecharge) {
                guard = true;
                shieldScript.gameObject.SetActive(true);
            }
            if (energyHPCur != energyHP) {
                energyHPCur += Time.deltaTime / energyRechargeTime * energyHP;
                if (energyHPCur >= energyHP) {
                    energyHPCur = energyHP;
                    if (shieldRecharge) {
                        shieldRecharge = false;
                    }
                }
            }
            if (justGuardTime != 0) {
                justGuardTime -= Time.deltaTime;
                if (justGuardTime < 0) {
                    justGuardTime = 0;
                }
            }
        }
        currentEnergyBar.GetComponent<Image>().fillAmount = energyHPCur / energyHP;
        Vector3 eneTriPos = currentEnergyTriangle.transform.localPosition;
        currentEnergyTriangle.transform.localPosition = new Vector3((energyHPCur / energyHP - 0.5f) * currentEnergyBar.GetComponent<RectTransform>().sizeDelta.x - currentEnergyTriangle.GetComponent<RectTransform>().sizeDelta.x / 2, eneTriPos.y, 0);
    }

    void LateUpdate() {
        if (groundJudge.onGround && jpNum == jpNumMax) {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }

    IEnumerator TimeStop(float time) {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1;
    }

    public void Damage(int damage) {
        if (guard) {
            energyHPCur -= damage;
            if (energyHPCur <= 0) {
                energyHPCur = 0;
                shieldRecharge = true;
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
                gameOver.Death(this, deathTimeStop);
            } else {
                StartCoroutine(TimeStop(justTimeStop / 2));
            }
            healthBar.GetComponent<Image>().fillAmount = (float)hp / (float)maxHP;
            Vector3 triPos = healthTriangle.transform.localPosition;
            healthTriangle.transform.localPosition = new Vector3(triPos.x - damage / (float)maxHP * healthBar.GetComponent<RectTransform>().sizeDelta.x , triPos.y, 0);
        }
        if (justGuardTime > 0) {
            StartCoroutine(TimeStop(justTimeStop));
            remainInvincible = remainInvincibleTime / 2;
            if (damage * energyHealing <= energyMaxHealing) {
                energyHPCur += damage * energyHealing;
            } else {
                energyHPCur += energyMaxHealing;
            }
            if (energyHPCur > energyHP) {
                energyHPCur = energyHP;
            }
        }
    }
}
