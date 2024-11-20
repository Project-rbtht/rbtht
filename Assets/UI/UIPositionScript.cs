using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPositionScript : MonoBehaviour
{
    public GameObject attack1;
    public GameObject attack2;
    public GameObject invincible;
    public float distance = 150;

    PlayerScript playerScript;

    private void Start() {
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
    }

    void Update() {
        if (!playerScript.attackActivated[1]) {
            attack1.SetActive(false);
            attack2.GetComponent<RectTransform>().anchoredPosition -= new Vector2(distance, 0);
            invincible.GetComponent<RectTransform>().anchoredPosition -= new Vector2(distance, 0);
        }
        if (!playerScript.attackActivated[2]) {
            attack2.SetActive(false);
            invincible.GetComponent<RectTransform>().anchoredPosition -= new Vector2(distance, 0);
        }
        this.gameObject.SetActive(false);
    }
}
