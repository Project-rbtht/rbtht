using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrownBullet : MonoBehaviour
{

    public GameObject explosion;
    private Rigidbody2D _rigid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
     if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("Player"))
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
}
