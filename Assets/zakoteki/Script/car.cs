using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
 public int kasoku = 10;
 public int waitFrame = 240;
 private SpriteRenderer sr = null;
 protected Rigidbody2D rb;
 bool onsensor;
 bool onrun;
 bool onexplosion;

 IEnumerator Start()
{
  if(sr.isVisible)
  {
    sr = GetComponent<SpriteRenderer>();
    Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
    yield return StartCoroutine(Idle);
  }
}


  IEnumerator Idle()
  {
    yield return new WaitForSeconds(0.01f);

    if(onsensor==true)
    {
    StartCoroutine(Find);
    }
  
  }

   IEnumerator Find()
   {
    if(onsensor == false)
    {
      StartCoroutine(Idle);
    }

    yield return new WaitForSeconds(waitFrame);
    onrun == true;

    if(onrun == true)
    {
      StartCoroutine(Run);
    }
   }

   IEnumerator Run()
   {
    yield return null;
    rb.velocity = new Vector3(-kasoku,rb.velocity.y,0);

     
       
    if(onexplosion == true)
    {
      StartCoroutine(Explosion);
    }
   }

   IEnumerator Explosion()
   {
    yield return new WaitForSeconds(1.0f);
    Destroy (this.gameObject) ;
   }

     void OnTriggerEnter2D (Collider2D collision)
     {
        if(collision.gameObject.tag == "Floor")
        {
            onexplosion==true;
        }
        if(collision.gameObject.tag == "Player")
        {
            onexplosion==true;
        }
      }
}
