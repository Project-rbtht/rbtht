using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvincibleScript : MonoBehaviour
{
    PlayerScript playerScript;
    Image image;
    bool justGuard = false;
    bool damaged = false;
    float invincibleTime;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        image = GetComponent<Image>();
        image.fillAmount = 0;
        invincibleTime = playerScript.invincibleTime / 2;
    }

    // Update is called once per frame
    void Update() {
        if (justGuard) {
            if (playerScript.remainInvincible > 0) {
                image.fillAmount = playerScript.remainInvincible / invincibleTime;
            } else if (image.fillAmount > 0) {
                image.fillAmount = 0;
                justGuard = false;
            }
        } else if (playerScript.remainInvincible > invincibleTime) {
            damaged = true;
        } else if (playerScript.remainInvincible > invincibleTime / 2 && !damaged) {
            justGuard = true;
        } else if(damaged && playerScript.remainInvincible < invincibleTime / 2) {
            damaged = false;
        }
    }
}
