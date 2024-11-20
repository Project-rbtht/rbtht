using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drown_Sensor : MonoBehaviour



{
    public bool _Ddetect;
    private Rigidbody2D _rigid;


    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter2D(Collider2D collision)
     {
         if(collision.CompareTag("Player"))
        {
         _Ddetect = true;
        }
     }   


    void OnTriggerExit2D(Collider2D collision)
     {
         if (collision.CompareTag("Player"))
         {
          _Ddetect = false;
         }
     }
}
