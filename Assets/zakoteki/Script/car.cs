using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
  public int hp = 2;
  public int recastTime = 1;
 public float kasoku = 10.0f;
 public float waitTime = 5.0f; 
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
Vector3 chaseVector;
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
  float dist = Vector3.Distance(transform.position, player.transform.position);
  Vector3 chaseVector = (player.transform.position - transform.position) / dist;
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
    StartCoroutine(Find());
    }
  
  }

   IEnumerator Find()
   {
    yield return null;
    FlipToPlayer();
    yield return new WaitForSeconds(waitTime);
   
     yield return null;
      onrun = true;
      Debug.Log("onrun");  
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

void OnTriggerHit2D (Collider2D collision)
     {
        if(collision.gameObject.tag == "Floor")
        {
            onexplosion=true;
            anim.SetBool("onexplosion",onexplosion);
            Debug.Log("hit player");
        }
        if(collision.gameObject.tag == "Player"||collision.gameObject.tag == "PlayerAttack")
        {
            onexplosion=true;
            anim.SetBool("onexplosion",onexplosion);
        }
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

  public void Damage(int ukerudamage) 
    {
        hp -= ukerudamage;
        if (hp <= 0) {
            Debug.Log("hp = " + hp);
            Destroy(this.gameObject);
        }
    }

}
