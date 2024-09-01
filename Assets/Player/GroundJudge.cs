using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundJudge : MonoBehaviour
{
    public bool onGround;
    public GameObject Player;
    private Animator anim = null;

    private void Start() {
        anim = Player.GetComponent<Animator>();
    }

<<<<<<< HEAD
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
=======
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Floor") {
            onGround = true;
            PlayerScript.jpNum = PlayerScript.jpNumMax;
            anim.SetInteger("Jump", 0);
            anim.SetTrigger("Ground");
        }
    }

    void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Floor") {
            onGround = true;
            PlayerScript.jpNum = PlayerScript.jpNumMax;
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Floor") {
            onGround = false;
            PlayerScript.jpNum = PlayerScript.jpNumMax - 1;
            anim.SetInteger("Jump", 1);
        }
>>>>>>> 0303008 (invincibility time after damaged)
    }
}
