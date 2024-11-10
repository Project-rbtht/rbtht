using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack2 : MonoBehaviour, Attack
{
    public int damage = 1;
    public GameObject ironBall;
    public float recastTime = 1;
    public GameObject player;
    public float speedX = 1.0f;
    public float speedY = 1.0f;

    Animator playerAnim;

    void Start() {
        playerAnim = player.GetComponent<Animator>();
        ironBall.GetComponent<IronBallScript>().damage = damage;
    }

    void OnEnable() {
        IronBallScript clone = Instantiate(ironBall, transform.position, transform.rotation).GetComponent<IronBallScript>();
        clone.player = player;
        clone.damage = damage;
        clone.speedX = speedX;
        clone.speedY = speedY;
        clone.direct = player.transform.localScale.x;
        StartCoroutine(FrameStop());
    }

    IEnumerator FrameStop() {
        yield return null;
        this.GameObject().SetActive(false);
    }

    public float RecastTime()
    {
        return recastTime;
    }
}