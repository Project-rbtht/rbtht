using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public void Death(PlayerScript player, float timeStop) {
        player.enabled = false;
        StartCoroutine(TimeStop(timeStop));
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, player.jpSpeed);
    }

    IEnumerator TimeStop(float time) {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(time);
        Time.timeScale = 1;
    }
}
