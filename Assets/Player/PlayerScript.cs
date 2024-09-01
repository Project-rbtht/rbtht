using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float speed = 0.1f;
    public int jpNumMax = 1;
    public float jpSpeed = 9.8f;
<<<<<<< HEAD
    public ground_judge groundJudge;
<<<<<<< HEAD
=======
=======
    public GroundJudge groundJudge;
>>>>>>> abe3006 (guard anim)
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
>>>>>>> 0303008 (invincibility time after damaged)

    Rigidbody2D rb;
    int jpNum;
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
<<<<<<< HEAD
=======
        counter = new float[attack.Length];
        Array.Fill<float>(counter, 0);
        shieldHPCur = shieldHP;
        hp = maxHP;
>>>>>>> abe3006 (guard anim)
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
<<<<<<< HEAD
=======

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
>>>>>>> 0303008 (invincibility time after damaged)
}
