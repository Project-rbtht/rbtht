using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zirai : MonoBehaviour
{
    public GameObject ziraiexplosion;
private Animator anim;
bool onsensor;
private SpriteRenderer sr = null;
protected Rigidbody2D rb;
public float waitTime = 0.5f; 
bool onexplosion;
public int hp = 2;
public int recastTime = 1;
private Transform childTransform;

void Start()
{
  //if(sr.isVisible)
  childTransform = transform.Find("Instantiate_Pos");
    anim = GetComponent<Animator>();
    sr = GetComponent<SpriteRenderer>();
    rb = GetComponent<Rigidbody2D>();
    StartCoroutine(Idle());
}

IEnumerator Idle()
  {
    yield return null;
    
  while (onsensor==false)
  {
    yield return null;
  }
    StartCoroutine(Find());
  }

IEnumerator Find()
{
yield return null;
yield return new WaitForSeconds(waitTime);
onexplosion = true;
anim.SetBool("onexplosion",onexplosion);
StartCoroutine(Explosion());
}

IEnumerator Explosion()
{
    yield return null;
    Instantiate(ziraiexplosion,childTransform.transform.position,childTransform.transform.rotation);
    yield return null;
    Destroy (this.gameObject);
}


    void OnTriggerEnter2D (Collider2D collision)
     {
        if(collision.gameObject.tag == "Player")
        {
            onsensor = true;
           anim.SetBool("onsensor",onsensor);
           StartCoroutine(Find());
        }
        if(collision.gameObject.tag == "PlayerAttack" && !onexplosion)
        {
            onexplosion = true;
            anim.SetBool("onexplosion",onexplosion);
           StartCoroutine(Explosion());
        }
     }

}
