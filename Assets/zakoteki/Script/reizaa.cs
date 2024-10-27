
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reizaa : MonoBehaviour
{
     private SpriteRenderer sr = null;
    protected Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
     
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
    

        float currentTime = 0f;
        const float recastTime = 0.1f;
        if(++currentTime > recastTime)
        {
            Instantiate(BulletObj,transform.position,transform.rotation);
            currentTime = 0f;
        }
        
   
    }

    void Stop()
        {
            rb.velocity = new Vector3(0,rb.velocity.y,0);
        }

    void OnTriggerEnter2D (Collider2D collision)
       {  
         if(collision.gameObject.tag == "Floor")
        {
            Stop();
        }
       }
}
