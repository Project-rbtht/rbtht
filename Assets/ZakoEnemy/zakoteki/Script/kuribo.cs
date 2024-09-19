using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
public class kuribo : MonoBehaviour
{
  public Rigidbody2D rid2d;
 public float hanntenn;
public float moveX;
      private SpriteRenderer sr = null; 
     void Start()
     {
        
     }
     
     void Update()
     {
      rid2d.velocity = new Vector2(moveX,0);
        //transform.position = transform.position + new Vector3(moveX, 0, 0 ) ;
        
     }
       void OnCollisionEnter2D (Collision2D butukattamono)
       {  
        
         if(butukattamono.gameObject.tag == "Wall")
        {
          moveX=moveX*hanntenn;
        }
       }
}
 