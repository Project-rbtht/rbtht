
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reizaa : MonoBehaviour
{
    private SpriteRenderer sr = null;
    protected Rigidbody2D rb; 
    private Animator anim;
    bool onsensor;
    public float waitTime = 1.2f;
    bool onescape;
    public GameObject player;
    public int damage = 1; 
    public int recastTime = 1;
    public Sensor sensor;
    public Escape_sensor sensor2;
    public GameObject BulletObj;
    public GameObject BeamObj;
    public float MoveSpeed = 2.0f;
    public float EscapeSpeed = 4.0f;
    public bool onshot;
    bool onbeam;
    bool onmove;
    private Transform childTransform;
    private float laserLength = 20.5f;
    GameObject spawnedObject;

    void Start()
    {
      childTransform = transform.Find("Instantiate_Pos");
      player = GameObject.Find("PlayerObject");
        sr = GetComponent<SpriteRenderer>();
     rb = this.GetComponent<Rigidbody2D>();
     anim = GetComponent<Animator>();
    StartCoroutine(Idle());
    }

    void Update()
    {
        onsensor=sensor.onsensor;
        onescape=sensor2.onescape;
    }

public void BodyDamage(Collider2D collision)
 {
  if (collision.gameObject.tag == "Player") {
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null) 
            {
                damageTarget.Damage(damage);
            }
        }
 }

 IEnumerator Idle()
  {
    yield return new WaitUntil(() => onsensor == true);
    StartCoroutine(Find());
  }

IEnumerator Find()
{
 yield return null;
 StartCoroutine (Chase());
}

IEnumerator Chase()
{
  yield return null;
  while(onescape==false)
  {
    FlipToPlayer();
    onmove=true;
    anim.SetBool("onmove",onmove);
    rb.velocity = new Vector3(-transform.right.x*MoveSpeed,rb.velocity.y,0);
    yield return new WaitForSeconds(0.1f*MoveSpeed);
    onmove=false;
    anim.SetBool("onmove",onmove);
    yield return new WaitForSeconds(waitTime-0.2f-0.1f*MoveSpeed);
    onshot=true;
    anim.SetBool("onshot",onshot);
    yield return new WaitForSeconds(0.2f);
    Instantiate(BulletObj,childTransform.transform.position,childTransform.transform.rotation);
    onshot=false;
    anim.SetBool("onshot",onshot);
  }

   if(onescape==true)
    {
      StartCoroutine(Escape());
    }
}

IEnumerator Escape()
{
  yield return null;
  while(onescape==true)
  {
    FlipToPlayer();
    onmove=true;
    anim.SetBool("onmove",onmove);
    rb.velocity = new Vector3(transform.right.x*EscapeSpeed,rb.velocity.y,0);
    yield return new WaitForSeconds(0.1f*EscapeSpeed);
    onmove=false;
    anim.SetBool("onmove",onmove);
    yield return new WaitForSeconds(waitTime-0.1f-0.1f*EscapeSpeed);
    rb.velocity = new Vector3(0,rb.velocity.y,0);
    yield return new WaitForSeconds(0.1f);
    spawnedObject=Instantiate(BeamObj,childTransform.transform.position + laserLength * -transform.right,childTransform.transform.rotation);
    spawnedObject.transform.SetParent(transform);
    yield return new WaitForSeconds(2.0f);
    onbeam=true;
    anim.SetBool("onbeam",onbeam);
    yield return new WaitForSeconds(2.3f);
    onbeam=false;
    anim.SetBool("onbeam",onbeam);
  }

  if(onescape==false)
    {
      StartCoroutine(Chase());
    }
}

void FlipToPlayer()
 {
  if(player.transform.position.x>transform.position.x)
  {
    transform.rotation = Quaternion.Euler(0,180,0);
  }
  else{
    transform.rotation = Quaternion.Euler(0,0,0);
  }
 }
}
