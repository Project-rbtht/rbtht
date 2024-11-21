using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public bool onsensor;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D (Collider2D collision)
     {
        if(collision.gameObject.tag == "Player")
        {
           onsensor = true;
           anim.SetBool("onsensor",onsensor);
        }
    }

    void OnTriggerExit2D (Collider2D collision)
     {
        if(collision.gameObject.tag == "Player")
        {
           onsensor = false;
           anim.SetBool("onsensor",onsensor);
        }
    }
}
