using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuibi_bakuha : MonoBehaviour
{
     private Transform playerPos;
     public float speed=2.0f;
     public GameObject explosion;
     public GameObject player;
     Rigidbody2D rb;
     public float chaseTime=3.0f;
     bool onchase;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerObject");
        playerPos = player.transform;
        rb=this.GetComponent<Rigidbody2D>();
        onchase=true;
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        Vector3 chaseVector = (player.transform.position - transform.position) / dist;

        if(onchase==true)
        {
            rb.velocity=(chaseVector * speed);
        }
    }

    IEnumerator Fire()
    {
        yield return null;
        yield return new WaitForSeconds(chaseTime);
        onchase=false;
        rb.velocity=new Vector3(0,-5,0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"||collision.gameObject.tag == "Floor"||collision.gameObject.tag == "PlayerAttack")
        {
            Instantiate(explosion,transform.position,transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
