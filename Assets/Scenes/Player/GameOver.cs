using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    GameObject circle;
    
    public void Death(PlayerScript player, float timeStop, float beforeCircle, float changeTime) {
        player.enabled = false;
        circle = GameObject.Find("Canvas/Circle");
        StartCoroutine(TimeStop(timeStop));
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player.jpSpeed);
        StartCoroutine(Sleep(beforeCircle, changeTime));
    }

    IEnumerator TimeStop(float time) {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(time);
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
