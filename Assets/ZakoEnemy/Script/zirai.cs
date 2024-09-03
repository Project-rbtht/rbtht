using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class zirai : MonoBehaviour
=======
public class 雑魚敵１＿地雷 : MonoBehaviour
>>>>>>> origin/player
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
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
=======
        
    }
>>>>>>> origin/player
}
