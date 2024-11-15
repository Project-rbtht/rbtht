using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagedBarScript : MonoBehaviour {
    public GameObject healthBar;
    public bool set = false;

    public float decSpeed = 1f;
    Image image;

    private void Start() {
        image = GetComponent<Image>();
        if(set){
            if (healthBar.GetComponent<Image>().fillAmount < image.fillAmount) {
                image.fillAmount = healthBar.GetComponent<Image>().fillAmount;
            }
            this.enabled = false;
        }
    }

    void Update() {
        image.fillAmount -= Time.deltaTime * decSpeed;
        if (healthBar.GetComponent<Image>().fillAmount >= image.fillAmount) {
            image.fillAmount = healthBar.GetComponent<Image>().fillAmount;
            this.enabled = false;
        }
    }
}