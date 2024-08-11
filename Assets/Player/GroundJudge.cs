using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_judge : MonoBehaviour
{
    public bool onGround;
    public GameObject Player;
    private Animator anim = null;

    private void Start() {
        anim = Player.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        onGround = true;
        anim.SetInteger("Jump", 0);
        anim.SetTrigger("Ground");
    }

    private void OnTriggerStay2D(Collider2D collision) {
        onGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        onGround = false;
        anim.SetInteger("Jump", 1);
    }
}
