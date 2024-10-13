using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour, Idamagable {

    //dont change in gaming
    public GroundJudge groundJudge;
    public GameObject[] attack = new GameObject[1];
    public ShieldScript shieldScript;
    public GameOver gameOverScript;
    public float jpSpeed = 9.8f;
    public float invincibleTime = 2.5f;
    public float justTimeStop = 0.2f;
    public float energyHealing = 0.5f; // energyHP / damage
    public float energyMaxHealing = 2f;
    public float deathTimeStop = 0.5f;
    public float deathBeforeCircleTime = 2f;
    public float deathCircleTime = 2f;

    //can temp buff
    public float speed = 0.1f;

    //can enhance
    public int maxHP = 1;
    public int jpNumMax = 1;
    public float justGuardTiming = 0.2f;
    public float shieldDecTime = 5;
    public float energyHP = 1;
    public float energyRechargeTime = 1;

    //can only see from other scripts
    public int jpNum;
    public float[] counter;
    public bool gameOver = false;
    public int hp = 0;

    Rigidbody2D rb;
    Animator anim = null;
    float remainInvincible = 0;
    bool guard = false;
    float energyHPCur = 0;
    float justGuardTime = 0;
    bool shieldRecharge = false;
    bool afterDamaged = false;
    float blinkingCycle = 0.14f;

    GameObject healthBar;
    GameObject healthTriangle;
    //GameObject damagedBar;
    //GameObject damagedTriangle;
    GameObject currentEnergyBar;
    GameObject currentEnergyTriangle;


    void Start () {
        healthBar = GameObject.Find("Canvas/HPBar/HPBackground/HealthBar");
        healthTriangle = GameObject.Find("Canvas/HPBar/HPBackground/HealthTriangle").gameObject;
        //damagedBar = GameObject.Find("Canvas/HPBar/HPBackground/DamagedBar").gameObject;
        //damagedTriangle = GameObject.Find("Canvas/HPBar/HPBackground/DamagedTriangle").gameObject;
        currentEnergyBar = GameObject.Find("Canvas/EnergyBar/EnergyBackground/CurrentEnergyBar").gameObject;
        currentEnergyTriangle = GameObject.Find("Canvas/EnergyBar/EnergyBackground/CurrentEnergyTriangle").gameObject;
        rb = this.GetComponent<Rigidbody2D>();
        jpNum = jpNumMax;
        anim = GetComponent<Animator>();
        counter = new float[attack.Length];
        Array.Fill<float>(counter, 0);
        energyHPCur = energyHP;
        if (hp == 0) {
            hp = maxHP;
        }
        healthBar.GetComponent<Image>().fillAmount = (float)hp / (float)maxHP;
        Vector3 triPos = healthTriangle.transform.localPosition;
        healthTriangle.transform.localPosition = new Vector3(triPos.x - (maxHP - hp) / (float)maxHP * healthBar.GetComponent<RectTransform>().sizeDelta.x, triPos.y, 0);
        this.gameObject.GetComponent<Renderer>().sortingOrder = 1;
        SceneManager.sceneLoaded += GameSceneLoaded;
    }

    // Update is called once per frame
    void Update() {
        //????
        float x = Input.GetAxisRaw("Horizontal");
        float speedY = rb.velocity.y;

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

        //?L?????N?^?[??????
        anim.SetInteger("Speed", (int)Mathf.Abs(x * 2));

        if (x != 0) {
            transform.localScale = new Vector3(x/Mathf.Abs(x), 1, 1);
        }

        //?U??
        for (int i = 0; i < attack.Length; i++) {
            if (Input.GetButtonDown("Attack" + i) == true && counter[i] == 0) {
                anim.SetTrigger("Attack" + i);
                counter[i] = attack[i].GetComponent<Attack>().recastTime;
            } else {
                counter[i] -= Time.deltaTime;
                if (counter[i] < 0) { counter[i] = 0; }
            }
        }

        //???G????
        if (remainInvincible > 0) {
            remainInvincible -= Time.deltaTime;
            if (remainInvincible <= 0) {
                remainInvincible = 0;
            }
        }

        if (afterDamaged){
            if (remainInvincible > 1) {
                var repeatValue = Mathf.Repeat(remainInvincible - 1f, blinkingCycle * 2);
                this.GetComponent<SpriteRenderer>().enabled = repeatValue <= blinkingCycle;
            }else if (remainInvincible > 0) {
                var repeatValue = Mathf.Repeat(remainInvincible, blinkingCycle);
                this.GetComponent<SpriteRenderer>().enabled = repeatValue <= blinkingCycle / 2;
            } else { 
                afterDamaged = false;
            }
        }

        //?K?[?h
        if (guard) {
            if (Input.GetButtonUp("Guard") == true) {
                guard = false;
                shieldScript.gameObject.SetActive(false);
                //justGuardTime = justGuardTiming;
            }
            energyHPCur -= Time.deltaTime / shieldDecTime * energyHP;
            if (energyHPCur <= 0) {
                energyHPCur = 0;
                guard = false;
                shieldScript.gameObject.SetActive(false);
                shieldRecharge = true;
                remainInvincible = invincibleTime / 10;
            }
        } else {
            if (Input.GetButton("Guard") == true && !shieldRecharge) {
                guard = true;
                shieldScript.gameObject.SetActive(true);
                justGuardTime = justGuardTiming;
            }
            //if (Input.GetButton("Guard") == true && justGuardTime == 0 && !shieldRecharge) {
            //    guard = true;
            //    shieldScript.gameObject.SetActive(true);
            //}
            if (energyHPCur != energyHP) {
                energyHPCur += Time.deltaTime / energyRechargeTime * energyHP;
                if (energyHPCur >= energyHP) {
                    energyHPCur = energyHP;
                    if (shieldRecharge) {
                        shieldRecharge = false;
                    }
                }
            }
        }
        if (justGuardTime != 0) {
            justGuardTime -= Time.deltaTime;
            if (justGuardTime < 0) {
                justGuardTime = 0;
            }
        }
        currentEnergyBar.GetComponent<Image>().fillAmount = energyHPCur / energyHP;
        Vector3 eneTriPos = currentEnergyTriangle.transform.localPosition;
        currentEnergyTriangle.transform.localPosition = new Vector3((energyHPCur / energyHP - 0.5f) * currentEnergyBar.GetComponent<RectTransform>().sizeDelta.x - currentEnergyTriangle.GetComponent<RectTransform>().sizeDelta.x / 2, eneTriPos.y, 0);

    }

    IEnumerator TimeStop(float time) {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1;
        if (afterDamaged){
            anim.SetBool("Damaged", false);
        }
    }

    public void Damage(int damage) {
        if (remainInvincible == 0) {
            if (justGuardTime > 0) {
                StartCoroutine(TimeStop(justTimeStop));
                remainInvincible = invincibleTime / 2;
                if (damage * energyHealing <= energyMaxHealing) {
                    energyHPCur += damage * energyHealing;
                } else {
                    energyHPCur += energyMaxHealing;
                }
                if (energyHPCur > energyHP) {
                    energyHPCur = energyHP;
                }
            }else if (guard) {
                energyHPCur -= damage;
                if (energyHPCur <= 0) {
                    energyHPCur = 0;
                    shieldRecharge = true;
                    guard = false;
                    shieldScript.gameObject.SetActive(false);
                    remainInvincible = invincibleTime / 10;
                }
            }else {
                hp -= damage;
                remainInvincible += invincibleTime;
                anim.SetBool("Damaged", true);
                if (hp <= 0) {
                    gameOver = true;
                    this.gameObject.layer = 1;
                    SceneManager.sceneLoaded -= GameSceneLoaded;
                    gameOverScript.Death(this, deathTimeStop, deathBeforeCircleTime, deathCircleTime);
                } else {
                    afterDamaged = true;
                    StartCoroutine(TimeStop(justTimeStop));
                }
                healthBar.GetComponent<Image>().fillAmount = (float)hp / (float)maxHP;
                Vector3 triPos = healthTriangle.transform.localPosition;
                healthTriangle.transform.localPosition = new Vector3(triPos.x - damage / (float)maxHP * healthBar.GetComponent<RectTransform>().sizeDelta.x , triPos.y, 0);
            }
        }
    }

    void GameSceneLoaded(Scene next, LoadSceneMode mode) {
        var nextPlayerScript = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        
        nextPlayerScript.maxHP = maxHP;
        nextPlayerScript.jpNumMax = jpNumMax;
        nextPlayerScript.justGuardTiming = justGuardTiming;
        nextPlayerScript.shieldDecTime = shieldDecTime;
        nextPlayerScript.energyHP = energyHP;
        nextPlayerScript.energyRechargeTime = energyRechargeTime;

        nextPlayerScript.hp = hp;

        SceneManager.sceneLoaded -= GameSceneLoaded;

    }

}
