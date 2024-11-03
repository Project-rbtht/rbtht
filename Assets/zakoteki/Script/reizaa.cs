
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reizaa : MonoBehaviour
{
     private SpriteRenderer sr = null;
    protected Rigidbody2D rb; 
    private Animator anim;
    bool onsensor;
    float waitTime;
    bool onescape;
    public GameObject player;
    public int hp = 2;
    public int damage = 1;
    public float recastTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
     anim = GetComponent<Animator>();
    StartCoroutine(Idle());
    }
public GameObject BulletObj;
public float transport = 0.1f;

    // Update is called once per frame
    void Update()
    {
        
          float posX, posY;
        posX = transform.position.x;
        posY = transform.position.y;
        transform.position = transform.position + new Vector3(transport, 0, 0 );
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

  public void Damage(int damage) 
    {
        hp -= damage;
        if (hp <= 0) {
            Debug.Log("hp = " + hp);
            Destroy(this.gameObject);
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
    StartCoroutine(Find());
    }
  
  }

IEnumerator Find()
{
 yield return null;

    while(onescape==false)
        {
            yield return null;
            Instantiate(BulletObj,transform.position,transform.rotation);
            yield return new WaitForSeconds(waitTime);
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
}
