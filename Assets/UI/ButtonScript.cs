using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
        
    public int maxHP = 1;
    public int jpNumMax = 1;
    public float justGuardGrace = 0.2f;
    public float shieldDecSpeed = 5;
    public float energyHP = 1;
    public float energyRechargeTime = 1;
    public string restartStage;
    public bool[] attackActivated;

    public AudioClip sound;
    AudioSource audioSource;
    public AudioManager audioManager;

    public void RestartButton() {
        audioManager.buttonSound = true;
        audioManager.sound = sound;
        SceneManager.sceneLoaded += GameSceneLoaded;
        SceneManager.LoadScene(restartStage);
    }

    public void StageButton() {
        audioManager.buttonSound = true;
        audioManager.sound = sound;
        SceneManager.sceneLoaded += BackStageSelect;
        SceneManager.LoadScene("scene0");
    }

    public void TitleButton() {
        audioManager.buttonSound = true;
        audioManager.sound = sound;
        SceneManager.LoadScene("TitleScene");
    }

    void GameSceneLoaded(Scene next, LoadSceneMode mode) {
        var nextPlayerScript = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();

        nextPlayerScript.maxHP = maxHP;
        nextPlayerScript.jpNumMax = jpNumMax;
        nextPlayerScript.justGuardGrace = justGuardGrace;
        nextPlayerScript.shieldDecSpeed = shieldDecSpeed;
        nextPlayerScript.energyHP = energyHP;
        nextPlayerScript.energyRechargeTime = energyRechargeTime;
        nextPlayerScript.restartStage = restartStage;
        nextPlayerScript.attackActivated = attackActivated;

        SceneManager.sceneLoaded -= GameSceneLoaded;
    }

    void BackStageSelect(Scene next, LoadSceneMode mode) {
        var nextPlayerScript = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();

        nextPlayerScript.maxHP = maxHP;
        nextPlayerScript.jpNumMax = jpNumMax;
        nextPlayerScript.justGuardGrace = justGuardGrace;
        nextPlayerScript.shieldDecSpeed = shieldDecSpeed;
        nextPlayerScript.energyHP = energyHP;
        nextPlayerScript.energyRechargeTime = energyRechargeTime;
        nextPlayerScript.restartStage = "";
        nextPlayerScript.attackActivated = attackActivated;

        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}
