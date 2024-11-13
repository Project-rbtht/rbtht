using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recovery_item : MonoBehaviour
{
    public GameObject player;
    public PlayerScript PlayerScript;
    public int curehealth=1;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            PlayerScript.hp=PlayerScript.hp+curehealth;
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
