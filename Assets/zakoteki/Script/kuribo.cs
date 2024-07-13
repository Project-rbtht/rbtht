using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
public class kuribo : MonoBehaviour
{
     　　 private SpriteRenderer sr = null; 
     void Start()
     {

     }
 public float hanntenn;
public float moveX;
     void Update()
     {
      
        transform.position = transform.position + new Vector3(moveX, 0, 0 ) ;
      
     }
       void OnTriggerEnter (Collider butukattamono)
       {  
        
         if(butukattamono.gameObject.tag == "Wall")
        {
        moveX = moveX * hanntenn;
        }
       }
}
 