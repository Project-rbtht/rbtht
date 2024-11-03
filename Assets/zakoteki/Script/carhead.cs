using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carhead : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D collision)
     {
        if(collision.gameObject.tag == "Floor")
        {
            Destroy (this.gameObject) ;
        }
    }
}
