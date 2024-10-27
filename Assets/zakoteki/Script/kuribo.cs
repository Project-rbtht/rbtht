using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
public class kuribo : MonoBehaviour
{
  private SpriteRenderer sr = null;
     void Start()
     {
      Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
      sr = GetComponent<SpriteRenderer>();
     }
 public float hanntenn=-1;
public float moveX = 1;


void OnTriggerEnter2D (Collider2D collision)
       {  
         if(collision.gameObject.tag == "Floor")
        {
        moveX = moveX * hanntenn;
        Flip();
        
        }

       }

void Flip()
{
  Vector3 scale = transform.localScale;;
  scale.x = -1;
  transform.localScale = scale;
} 

     void FixedUpdate()
   {
             Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(-moveX,rb.velocity.y,0);
   }
       
}
 