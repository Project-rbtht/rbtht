using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
  public int hp = 2;
  public int recastTime = 1;
 public float kasoku = 10.0f;
 public float waitTime = 2.0f; 
 private SpriteRenderer sr = null;
 protected Rigidbody2D rb;
 public Sensor sensor;
 bool onsensor;
 bool onrun;
 bool onexplosion;
 private Animator anim;
private Transform playerPos;
public GameObject player;
public GameObject explosion;
 float elapsedTime = 0f;


 public void BodyDamage(Collider2D collision)
 {
  if (collision.gameObject.tag == "Player"||collision.gameObject.tag == "PlayerAttack") {
           
            onexplosion=true;
            if(onexplosion == true)
            {
              StartCoroutine(Explosion());
            }
        }
  if (collision.gameObject.tag == "Floor") {
  onexplosion=true;
  StartCoroutine(Explosion());
  }
 }


void Start()
{
  //if(sr.isVisible)
    anim = GetComponent<Animator>();
    sr = GetComponent<SpriteRenderer>();
    rb = GetComponent<Rigidbody2D>();
   onsensor=false;
   onexplosion=false;
   onrun=false;
   player = GameObject.Find("PlayerObject");
   playerPos = player.transform;
   StartCoroutine(Idle());
}

void Update()
{
  onsensor=sensor.onsensor;
 
  if(onsensor==true&&onrun==false)
  {
    FlipToPlayer();
  }
}


  IEnumerator Idle()
  {
    yield return null;
  while (onsensor==false)
  {
    
    yield return null;
  }
  
    if(onsensor==true)
    {
       anim.SetBool("onsensor",onsensor);
    StartCoroutine(Find());
   
    }
  
  }

   IEnumerator Find()
   {
    yield return new WaitForSeconds(waitTime);
      onrun = true;
     
      anim.SetBool("onrun",onrun);
    
    yield return null;
    

    if(onrun == true)
    {
      StartCoroutine(Run());
    }
   }

   IEnumerator Run()
   {
    yield return null;
    while (onexplosion==false)
        {
            rb.velocity = new Vector3(transform.right.x*kasoku,rb.velocity.y,0);
            yield return null; // 次のフレームを待つ
        }
     
    if(onexplosion == true)
    {
      StartCoroutine(Explosion());
    }
   }

   IEnumerator Explosion()
   {
    yield return null;
    Instantiate(explosion,transform.position,transform.rotation);
    Destroy (this.gameObject) ;
   }

 void FlipToPlayer()
 {
  if(player.transform.position.x>transform.position.x)
  {
    transform.rotation = Quaternion.Euler(0,0,0);
  }
  else{
    transform.rotation = Quaternion.Euler(0,180,0);
  }
 }

}
