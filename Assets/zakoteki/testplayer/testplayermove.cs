using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testplayermove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
 public GameObject bullet ;
    // Update is called once per frame
    void Update()
    {
        float posX, posY;
        posX = transform.position.x;
        posY = transform.position.y;

        if(Input.GetKey (KeyCode.UpArrow))/**/
        {
            posY = posY + 0.1f;
        }
        if(Input.GetKey (KeyCode.DownArrow))/**/
        {
            posY = posY - 0.1f;
        }
        if(Input.GetKey (KeyCode.LeftArrow))/**/
        {
            posX = posX - 0.1f;
        }
        if(Input.GetKey (KeyCode.RightArrow))/**/
        {
            posX = posX + 0.1f;
        }

     transform.position = new Vector3(posX, posY, 0) ;
     

     if(Input.GetKeyDown(KeyCode.Z))
     {

      Instantiate(bullet, transform.position, transform.rotation) ;

     }
    }
}
