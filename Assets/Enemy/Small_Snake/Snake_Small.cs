using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Small : EnemyBase //注意１EnemyBaseの継承とMonobehaviourを消す
{
    // Start is called before the first frame update
    private bool goToPlayer;
    void Start()
    {
        base.Start();//注意２この行を足す
        Debug.Log("Snake_Small Start keisyouTest");
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();//注意３この行も足す
        FlipToPlayer();
        Debug.Log("Snake_Small Update keisyouTest");

        rigidbody2d.AddForce(transform.right * speed);
    }
    
    void Forward()//前進する
    {

    }
}
