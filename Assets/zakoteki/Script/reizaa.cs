using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reizaa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

public float transport = 0.1f;
    // Update is called once per frame
    void Update()
    {
          float posX, posY;
        posX = transform.position.x;
        posY = transform.position.y;

        if(Input.GetKey (KeyCode.UpArrow))/**/
        {
            posY = posY + transport;
        }
        if(Input.GetKey (KeyCode.DownArrow))/**/
        {
            posY = posY - transport;
        }
        if(Input.GetKey (KeyCode.LeftArrow))/**/
        {
            posX = posX - transport;
        }
        if(Input.GetKey (KeyCode.RightArrow))/**/
        {
            posX = posX + transport;
        }

    transform.position = new Vector3(posX, posY, 0) ;
        
        if(Input.GetKeyDown(KeyCode.UpArrow)){



}

    }

     void OnTriggerEnter (Collider butukattamono)
     {
        if(butukattamono.gameObject.tag == "Player")
        {
            Destroy (this.gameObject) ;//こいつは消える//
            //プレイヤーにダメージ//
        }

         if(butukattamono.gameObject.tag == "PlayerAttack")
        {
            Destroy (this.gameObject) ;//こいつは消える//
        }
     }
}
