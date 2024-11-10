using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bulletreizaa : MonoBehaviour
{
    public float BulletSpeed = 7.0f;   
    public int damage = 1;
    public float recastTime = 1;
    protected Rigidbody2D rb;
    public float deleteTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
        StartCoroutine (Fire());
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null) 
            {
                damageTarget.Damage(damage);
            }
        }
        if(collision.gameObject.tag == "Floor")
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    IEnumerator Fire()
    {
        yield return null;
        rb.velocity = new Vector3(-transform.right.x*BulletSpeed,0,0);
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }

}
