using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carbody : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        transform.root.gameObject.GetComponent<car>().BodyDamage(collision);
    }

    
}
