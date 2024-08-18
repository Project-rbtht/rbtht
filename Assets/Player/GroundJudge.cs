using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_judge : MonoBehaviour
{
    public bool onGround;
    public GameObject Player;
    public PlayerScript PlayerScript;

    Animator anim = null;

    void Start() {
        anim = Player.GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision) {
        onGround = true;
        PlayerScript.jpNum = PlayerScript.jpNumMax;
        anim.SetInteger("Jump", 0);
        anim.SetTrigger("Ground");
    }

    void OnTriggerStay2D(Collider2D collision) {
        onGround = true;
        PlayerScript.jpNum = PlayerScript.jpNumMax;
    }

    void OnTriggerExit2D(Collider2D collision) {
        onGround = false;
        PlayerScript.jpNum = PlayerScript.jpNumMax - 1;
        anim.SetInteger("Jump", 1);
    }
}
