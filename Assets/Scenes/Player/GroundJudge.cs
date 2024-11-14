using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundJudge : MonoBehaviour
{
    public bool onGround;
    public GameObject Player;
    public PlayerScript PlayerScript;

    Animator anim = null;

    void Start() {
        anim = Player.GetComponent<Animator>();
    }

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
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Air")) {
                anim.SetInteger("Jump", 0);
                anim.SetTrigger("Ground");
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Floor") {
            onGround = false;
            PlayerScript.jpNum = PlayerScript.jpNumMax - 1;
            anim.SetInteger("Jump", 1);
        }
    }
}
