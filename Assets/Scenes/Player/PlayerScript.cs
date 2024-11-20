using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class PlayerScript : MonoBehaviour, Idamagable {

    public string restartStage = "";

    //dont change in gaming
    public GroundJudge groundJudge;
    //public GameObject[] attack = new GameObject[1];
    //public AudioClip sound;
    public AttackClass[] attackList = new AttackClass[1];
    public bool[] attackActivated = null;
    public AudioClip[] sounds;
    public AudioClip[] walkSounds;
    public ShieldScript shieldScript;
    public GameOver gameOverScript;
    public float jpSpeed = 9.8f;
    public float invincibleTime = 2.5f;
    public float damagedTimeStop = 0.2f;
    public float justGuardTimeStop = 0.2f;
    public float energyHealing = 0.5f; // energyHP / damage
    public float energyMaxHealing = 2f;
    public float deathTimeStop = 0.5f;
    public float deathBeforeCircleTime = 2f;
    public float deathCircleTime = 2f;
    public float waitTimeDamaged = 1f;
    public float gravityScale = 2f;

    //can temp buff
    public float speed = 0.1f;

    //can enhance
    public int maxHP = 1;
    public int jpNumMax = 1;
    public float justGuardGrace = 0.2f;
    public float shieldDecSpeed = 5;
    public float energyHP = 1;
    public float energyRechargeTime = 1;
    //public List<bool> attackActivated = new List<bool>();

    public bool canMove = true;

    //can only see from other scripts
    public int jpNum;
    public float[] counter;
    public bool gameOver = false;
    public int hp = 0;

    public FootScript foot;
    public bool justJump = false;

    Rigidbody2D rb;
    Animator anim = null;
    public float remainInvincible = 0;
    bool guard = false;
    float energyHPCur = 0;
    float justGuardTime = 0;
    bool shieldRecharge = false;
    bool afterDamaged = false;
    float blinkingCycle = 0.14f;
    public bool collide = false;
    public bool sakamichi = false;

    Vector2 normalVector = Vector2.zero;

    GameObject healthBar;
    GameObject healthTriangle;
    GameObject damagedBar;
    GameObject damagedTriangle;
    GameObject currentEnergyBar;
    GameObject currentEnergyTriangle;
    Color energyBarColor;
    GameObject Menu;
    public AudioSource audioSource;


    void Start () {
        if (restartStage == "") {
            restartStage = SceneManager.GetActiveScene().name;
            ReStart();
        }
        if (SceneManager.GetActiveScene().name == "scene0") {
            restartStage = "";
        }
        healthBar = GameObject.Find("Canvas/HPBar/HPBackground/HealthBar");
        healthTriangle = GameObject.Find("Canvas/HPBar/HPBackground/HealthTriangle").gameObject;
        damagedBar = GameObject.Find("Canvas/HPBar/HPBackground/DamagedBar").gameObject;
        damagedTriangle = GameObject.Find("Canvas/HPBar/HPBackground/DamagedTriangle").gameObject;
        currentEnergyBar = GameObject.Find("Canvas/EnergyBar/EnergyBackground/CurrentEnergyBar");
        currentEnergyTriangle = GameObject.Find("Canvas/EnergyBar/EnergyBackground/CurrentEnergyTriangle");
        rb = this.GetComponent<Rigidbody2D>();
        jpNum = jpNumMax;
        anim = GetComponent<Animator>();
        counter = new float[attackList.Length];
        Array.Fill<float>(counter, 0);
        if (attackActivated == null) {
            attackActivated = new bool[attackList.Length];
            attackActivated[0] = true;
            for (int i = 1; i < attackList.Length; i++) {
                attackActivated[i] = false;
            }
        }
        energyHPCur = energyHP;
        if (hp == 0) {
            hp = maxHP;
        }
        healthBar.GetComponent<Image>().fillAmount = (float)hp / (float)maxHP;
        Vector3 triPos = healthTriangle.transform.localPosition;
        healthTriangle.transform.localPosition = new Vector3(triPos.x - (maxHP - hp) / (float)maxHP * healthBar.GetComponent<RectTransform>().sizeDelta.x, triPos.y, 0);
        if (maxHP > hp) {
            damagedBar.GetComponent<DamagedBarScript>().enabled = true;
            damagedTriangle.GetComponent<DamagedTriangleScript>().enabled = true;
            damagedBar.GetComponent<DamagedBarScript>().set = true;
            damagedTriangle.GetComponent<DamagedTriangleScript>().set = true;
        }
        this.gameObject.GetComponent<Renderer>().sortingOrder = 1;
        SceneManager.sceneLoaded += GameSceneLoaded;
        energyBarColor = currentEnergyBar.GetComponent<Image>().color;
        Menu = GameObject.FindWithTag("Menu");
        Menu.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        //if (collision.gameObject.tag == "Floor") {
            collide = true;
            normalVector = collision.contacts[0].normal;
        //}
    }

    void OnCollisionStay2D(Collision2D collision) {
        //if (collision.gameObject.tag == "Floor") {
            collide = true;
            normalVector = collision.contacts[0].normal;
        //}
    }
    void OnCollisionExit2D(Collision2D collision) {
        //if (collision.gameObject.tag == "Floor") {
            collide = false;
        //}
    }

    //void LateUpdate() {
    //    Debug.Log("late v" + rb.velocity);
    //}

    void Update() {
        // Move
        if (canMove) {
            //float x = Input.GetAxisRaw("Horizontal");
            //float speedY = rb.velocity.y;

            
            //if (speedY < 0 && anim.GetInteger("Jump") > 0) {
            //    anim.SetInteger("Jump", -1);
            //}

            //if (Input.GetButtonDown("Jump") == true) {
            //    if (jpNum > 0) {
            //        speedY = jpSpeed;
            //        if (foot.onGround == true) {
            //            //if (groundJudge.onGround == true) {
            //            justJump = true;
            //            anim.SetInteger("Jump", 1);
            //            audioSource.PlayOneShot(sounds[0]);
            //            foot.onGround = false;
            //            sakamichi = false;
            //        } else {
            //            anim.SetInteger("Jump", 2);
            //            audioSource.PlayOneShot(sounds[1]);
            //        }
            //        jpNum--;
            //    }
            //}

            //if (!foot.onGround && sakamichi) {
            //    speedY = 0;
            //    sakamichi = false;
            //}


            //if (jpNum == jpNumMax && foot.onGround) {
            //    //if (jpNum == jpNumMax && foot.onGround) {
            //    rb.gravityScale = 0;
            //    rb.velocity = speed * foot.groundVector * Mathf.Sign(foot.groundVector.x) * x;
            //    //rb.velocity = speed * foot.groundVector * x / foot.groundVector.x;
            //    //rb.velocity = speed * normalVector * Mathf.Sign(normalVector.x) * x;
            //    sakamichi = true;
            //} else {
            //    rb.gravityScale = gravityScale;
            //    if ((foot.onWall && Mathf.Sign(foot.normalVector.x) != x) || (collide && Mathf.Sign(normalVector.x) != x)) {
            //        rb.velocity = new Vector2(0, speedY);
            //    } else {
            //        rb.velocity = new Vector2(x * speed, speedY);
            //    }
            //}

            //anim.SetInteger("Speed", (int)Mathf.Abs(x * 2));

            //// Direction
            //if (x != 0) {
            //    transform.localScale = new Vector3(x / Mathf.Abs(x), 1, 1);
            //}

            // Attack
            for (int i = 0; i < attackList.Length; i++) {
                if (attackActivated[i]) {
                    if (Input.GetButtonDown("Attack" + i) == true && counter[i] == 0) {
                        attackList[i].gameObject.SetActive(true);
                        counter[i] = attackList[i].gameObject.GetComponent<Attack>().RecastTime();
                        audioSource.PlayOneShot(attackList[i].sound);
                        anim.SetTrigger("Attack" + i);
                    } else if (counter[i] != 0) {
                        counter[i] -= Time.deltaTime;
                        if (counter[i] < 0) { counter[i] = 0; }
                    }
                }
            }
        }

        // Invincible
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

        // Guard
        if (guard) {
            if (Input.GetButtonUp("Guard") == true) {
                guard = false;
                //justGuardTime = justGuardGrace;
                if (!shieldScript.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Just")) {
                    shieldScript.gameObject.SetActive(false);
                }
            }
            EnergyBarDec(Time.deltaTime / shieldDecSpeed * energyHP);
        } else {
            if (Input.GetButton("Guard") == true && !shieldRecharge && canMove) {
                guard = true;
                shieldScript.gameObject.SetActive(true);
                justGuardTime = justGuardGrace;
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
                        currentEnergyBar.GetComponent<Image>().color = energyBarColor;
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

        //Menu
        if (Input.GetButtonDown("Menu")) {
            if (Menu.activeSelf) {
                Menu.SetActive(false);
                audioSource.UnPause();
                SceneManager.sceneLoaded += GameSceneLoaded;
            } else{
                Menu.SetActive(true);
                audioSource.Pause();
                SceneManager.sceneLoaded -= GameSceneLoaded;
            }
        }

        if (Input.GetKey(KeyCode.Alpha1) && Input.GetKey(KeyCode.Tab) && Input.GetKey(KeyCode.RightShift)) {
            GetAbility(1);
            counter[1] = 0;
        }
        if (Input.GetKey(KeyCode.Alpha2) && Input.GetKey(KeyCode.Tab) && Input.GetKey(KeyCode.RightShift)) {
            GetAbility(2);
            counter[2] = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5)){
            Save();
        }
        if (Input.GetKeyDown(KeyCode.Delete)) {
            SaveDelete();
        }
    }

    public void EnergyBarDec(float diff) {
        energyHPCur -= diff;
        if (energyHPCur <= 0) {
            audioSource.PlayOneShot(sounds[3]);
            energyHPCur = 0;
            shieldRecharge = true;
            guard = false;
            shieldScript.gameObject.SetActive(false);
            remainInvincible = invincibleTime / 10;
            currentEnergyBar.GetComponent<Image>().color = new Color(255f, 255f, 255f, 0.4f);
        }
    }

    public void GetAbility(int kind) {
        attackActivated[kind] = true;
    }

    public void Heal(int amount) {
        hp += amount;
        if(hp > maxHP) hp = maxHP;
        audioSource.PlayOneShot(sounds[5]);
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
                shieldScript.gameObject.SetActive(true);
                shieldScript.JustShield(justGuardTimeStop);
                audioSource.PlayOneShot(sounds[7]);
                StartCoroutine(TimeStop(justGuardTimeStop));
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
                audioSource.PlayOneShot(sounds[2]);
                EnergyBarDec(damage);
            }else {
                audioSource.PlayOneShot(sounds[5]);
                hp -= damage;
                remainInvincible += invincibleTime;
                anim.SetBool("Damaged", true);
                if (hp <= 0) {
                    Death();
                } else {
                    afterDamaged = true;
                    StartCoroutine(TimeStop(damagedTimeStop));
                }
                StartCoroutine(DamagedUI());
                healthBar.GetComponent<Image>().fillAmount = (float)hp / (float)maxHP;
                Vector3 triPos = healthTriangle.transform.localPosition;
                healthTriangle.transform.localPosition = new Vector3(triPos.x - damage / (float)maxHP * healthBar.GetComponent<RectTransform>().sizeDelta.x , triPos.y, 0);
            }
        }
    }

    IEnumerator DamagedUI() {
        yield return new WaitForSeconds(waitTimeDamaged);
        damagedBar.GetComponent<DamagedBarScript>().enabled = true;
        damagedTriangle.GetComponent<DamagedTriangleScript>().enabled = true;
    }

    public void Death() {
        anim.SetBool("Damaged", true);
        gameOver = true;
        foot.enabled = false;
        rb.gravityScale = gravityScale;
        this.gameObject.layer = 1;
        foot.gameObject.layer = 1;
        SceneManager.sceneLoaded -= GameSceneLoaded;
        SceneManager.sceneLoaded += GameOverSceneLoaded;
        gameOverScript.Death(this, deathTimeStop, deathBeforeCircleTime, deathCircleTime, sounds[6]);
    }

    public void Hit() {
        audioSource.PlayOneShot(sounds[4]);
    }
    public void PlayFootstepSE() {
        audioSource.PlayOneShot(walkSounds[UnityEngine.Random.Range(0, walkSounds.Length)]);
    }

    void GameSceneLoaded(Scene next, LoadSceneMode mode) {
        var nextPlayerScript = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        if (nextPlayerScript != null) {
            nextPlayerScript.maxHP = maxHP;
            nextPlayerScript.jpNumMax = jpNumMax;
            nextPlayerScript.justGuardGrace = justGuardGrace;
            nextPlayerScript.shieldDecSpeed = shieldDecSpeed;
            nextPlayerScript.energyHP = energyHP;
            nextPlayerScript.energyRechargeTime = energyRechargeTime;
            nextPlayerScript.restartStage = restartStage;
            nextPlayerScript.attackActivated = attackActivated;

            nextPlayerScript.hp = hp;

            SceneManager.sceneLoaded -= GameSceneLoaded;
        }
    }

    void GameOverSceneLoaded(Scene next, LoadSceneMode mode) {
        var nextPlayerScript = GameObject.FindWithTag("Respawn").GetComponent<ButtonScript>();

        nextPlayerScript.maxHP = maxHP;
        nextPlayerScript.jpNumMax = jpNumMax;
        nextPlayerScript.justGuardGrace = justGuardGrace;
        nextPlayerScript.shieldDecSpeed = shieldDecSpeed;
        nextPlayerScript.energyHP = energyHP;
        nextPlayerScript.energyRechargeTime = energyRechargeTime;
        nextPlayerScript.restartStage = restartStage;
        nextPlayerScript.attackActivated = attackActivated;

        Save();

        SceneManager.sceneLoaded -= GameOverSceneLoaded;

    }

    class SaveData {
        public int maxHP;
        public int jpNumMax;
        public float justGuardGrace;
        public float shieldDecSpeed;
        public float energyHP;
        public float energyRechargeTime;
        public bool[] attackActivated;
    }

    public void Save() {
        SaveData data = new();
        data.maxHP = maxHP;
        data.jpNumMax = jpNumMax;
        data.justGuardGrace = justGuardGrace;
        data.shieldDecSpeed = shieldDecSpeed;
        data.energyHP = energyHP;
        data.energyRechargeTime = energyRechargeTime;
        data.attackActivated = attackActivated;
        string saveData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("data", saveData);
        PlayerPrefs.Save();
        Debug.Log("saved");
    }

    public void SaveDelete() {
        PlayerPrefs.DeleteKey("data");
        Debug.Log("Deleted");
    }

    public void ReStart() {
        if (PlayerPrefs.HasKey("data")) {
            SaveData data = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString("data", null));
            maxHP = data.maxHP;
            jpNumMax = data.jpNumMax;
            justGuardGrace = data.justGuardGrace;
            shieldDecSpeed = data.shieldDecSpeed;
            energyHP = data.energyHP;
            energyRechargeTime = data.energyRechargeTime;
            attackActivated = data.attackActivated;
            Debug.Log("Reloaded");
        }
    }

}