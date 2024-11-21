using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuBottunScript : MonoBehaviour {
    public AudioClip[] sounds;
    AudioSource audioSource;
    public GameObject stageButton;
    public AudioManager audioManager;

    bool canMove = true;

    PlayerScript playerObj;
    void Awake() {
        if(SceneManager.GetActiveScene().name == "scene0") {
            stageButton.SetActive(false);
        }
        playerObj = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
    }

    public void BackTitle() {
        playerObj.Save();
        audioManager.buttonSound = true;
        audioManager.sound = sounds[1];
        SceneManager.LoadScene("TitleScene");
    }

    public void Stage() {
        playerObj.Save();
        audioManager.buttonSound = true;
        audioManager.sound = sounds[1];
        SceneManager.LoadScene("scene0");
    }

    public void Continue() {
        playerObj.gameObject.GetComponent<AudioSource>().PlayOneShot(sounds[1]);
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
