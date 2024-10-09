using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zirai : MonoBehaviour
{
    void OnTriggerEnter (Collider butukattamono)
     {
        if(butukattamono.gameObject.tag == "Player")
        {
            Destroy (this.gameObject) ;
        }
    
     }
}
