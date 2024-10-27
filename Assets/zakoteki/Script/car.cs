using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
public int kasoku = 100;
int frameCount = 0;
public int waitFrame = 240;
private SpriteRenderer sr = null;
protected Rigidbody2D rb;
void Start()
{
    sr = GetComponent<SpriteRenderer>();
    Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
}


   void FixedUpdate()
   {
     if (sr.isVisible)
     {
      if (++frameCount > waitFrame)
        {
            Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(-kasoku,0,0);
            Vector3 force = new Vector3(-kasoku,0,0);
            rb.AddForce(force, ForceMode2D.Force);
        }
     } 
   }

   
}
