
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reizaa : MonoBehaviour
{
     //bulletプレハブ
    public GameObject bullet;
   
    //弾丸のスピード
    public float speed = 5.0f;
    //敵生成時間間隔
    public float interval;
    //経過時間
    private float time = 0f;
    // Start is called before the first frame update
    
    void Start()
    {
           //時間間隔を決定する
        interval = interval;
    }

public float MoveSpeed = 0.01f;
    // Update is called once per frame
    void Update()
    {
          time += Time.deltaTime;
        //スペースが押されたとき
        if (time >interval)
        {
           Instantiate(bullet, transform.position, transform.rotation);
           
            //時間リセット
            time = 0;
        }
         float posX, posY;
        posX = transform.position.x;
        posY = transform.position.y;

       
        
        if(Input.GetKey (KeyCode.LeftArrow))/**/
        {
            posX = posX - MoveSpeed;
        }
        if(Input.GetKey (KeyCode.RightArrow))/**/
        {
            posX = posX + MoveSpeed;
        }

    transform.position = new Vector3(posX, posY, 0) ;
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