using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape_sensor : MonoBehaviour
{
    private Animator anim;
    public bool onescape;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           onescape = true;
           anim.SetBool("onescape",onescape);
        }
    }

    void OnTriggerExit2D (Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           onescape = false;
           anim.SetBool("onescape",onescape);
        }
    }
}
