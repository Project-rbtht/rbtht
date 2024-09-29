using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
public int kasoku = 100;
protected Rigidbody2D rb;
int frameCount = 0;
public int waitFrame = 240;
public GameObject carhead;
   void FixedUpdate()
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
