using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBottunScript : MonoBehaviour {
    PlayerScript playerObj;
    void Awake() {
        playerObj = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
    }

    public void BackTitle() {
        SceneManager.LoadScene("menu");
    }

    public void Continue() {
        this.gameObject.SetActive(false);
    }

    void OnEnable() {
        playerObj.canMove = false;
        Time.timeScale = 0;
    }

    void OnDisable() {
        Time.timeScale = 1;
        playerObj.canMove = true;
    }
}
