using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bulletreizaa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

  public float MoveSpeed = 0.5f;   
    
    // Update is called once per frame

    void Update()
    {
          transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);

       Destroy(this.gameObject);
       int frameCount = 0;             
       const int deleteFrame = 180;    

        if (++frameCount > deleteFrame)
        {
            Destroy(this.gameObject);
        }


    }
}
