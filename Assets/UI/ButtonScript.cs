using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public string preStage;
        
    public int maxHP = 1;
    public int jpNumMax = 1;
    public float justGuardGrace = 0.2f;
    public float shieldDecSpeed = 5;
    public float energyHP = 1;
    public float energyRechargeTime = 1;
    public AttackClass[] attackList;
    public string restartStage;
    public bool[] attackActivated;

    public void RestartButton() {
        SceneManager.sceneLoaded += GameSceneLoaded;
        SceneManager.LoadScene(preStage);
    }

    public void MenuButton() {
        SceneManager.LoadScene("menu");
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
}
