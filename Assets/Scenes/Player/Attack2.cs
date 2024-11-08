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

    Animator playerAnim;

    void Start() {
        playerAnim = player.GetComponent<Animator>();
        ironBall.GetComponent<IronBallScript>().damage = damage;
    }

    void OnEnable() {
        ironBall.GetComponent<IronBallScript>().direct = player.transform.localScale.x;
        Instantiate(ironBall, transform.position, transform.rotation);
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