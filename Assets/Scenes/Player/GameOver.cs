using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    GameObject circle;
    GameObject HPBar;
    GameObject EnergyBar;
    
    public void Death(PlayerScript player, float timeStop, float beforeCircle, float changeTime) {
        player.enabled = false;
        circle = GameObject.Find("Canvas/Circle");
        HPBar = GameObject.Find("Canvas/HPBar");
        EnergyBar = GameObject.Find("Canvas/EnergyBar");
        StartCoroutine(TimeStop(timeStop, beforeCircle / 2));
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player.jpSpeed);
        StartCoroutine(Sleep(beforeCircle, changeTime));
    }

    IEnumerator TimeStop(float time, float beforeCircle) {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(time);
        HPBar.GetComponent<BarScript>().enabled = true;
        HPBar.GetComponent<BarScript>().time = beforeCircle;
        EnergyBar.GetComponent<BarScript>().enabled = true;
        EnergyBar.GetComponent<BarScript>().time = beforeCircle;
        Time.timeScale = 1;
    }

    IEnumerator Sleep(float time, float changeTime)
    {
        yield return new WaitForSecondsRealtime(time);
        circle.GetComponent<CircleScript>().enabled = true;
        circle.GetComponent<CircleScript>().time = changeTime;
        StartCoroutine(Loading(changeTime));
    }

    IEnumerator Loading(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        SceneManager.LoadScene("GameOver");
    }
}
