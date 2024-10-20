using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zirai : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         float posX, posY;
        posX = transform.position.x;
        posY = transform.position.y;

         transform.position = new Vector2(posX, posY) ;
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
