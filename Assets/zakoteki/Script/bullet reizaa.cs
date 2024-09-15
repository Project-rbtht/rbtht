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
        
        float posX, posY;
posX = transform.position.x;
posY = transform.position.y;
       posX = posX - MoveSpeed;
       transform.position = new Vector3(posX, posY, 0) ;
    }

 void OnBecameInvisible()
    {
        GameObject.Destroy(this.gameObject);
    }

    
}
