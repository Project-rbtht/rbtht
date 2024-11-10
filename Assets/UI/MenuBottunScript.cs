using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBottunScript : MonoBehaviour {
    public AudioClip[] sounds;
    AudioSource audioSource;

    bool canMove = true;

    PlayerScript playerObj;
    void Awake() {
        playerObj = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
    }

    public void BackTitle() {
        audioSource.PlayOneShot(sounds[1]);
        SceneManager.LoadScene("menu");
    }

    public void Continue() {
        audioSource.PlayOneShot(sounds[1]);
        this.gameObject.SetActive(false);
    }

    void OnEnable() {
        if (audioSource == null) {
            audioSource = GetComponent<AudioSource>();
        } else {
            audioSource.PlayOneShot(sounds[0]);
            canMove = playerObj.canMove;
            playerObj.canMove = false;
            Time.timeScale = 0;
        }
    }

    void OnDisable() {
        Time.timeScale = 1;
        playerObj.canMove = canMove;
    }
}
