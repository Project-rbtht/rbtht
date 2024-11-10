using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Small : EnemyBase //’ˆÓ‚PEnemyBase‚ÌŒp³‚ÆMonobehaviour‚ğÁ‚·
{
    // Start is called before the first frame update
    private bool goToPlayer;
    void Start()
    {
        base.Start();//’ˆÓ‚Q‚±‚Ìs‚ğ‘«‚·
        Debug.Log("Snake_Small Start keisyouTest");
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();//’ˆÓ‚R‚±‚Ìs‚à‘«‚·
        FlipToPlayer();
        Debug.Log("Snake_Small Update keisyouTest");

        rigidbody2d.AddForce(transform.right * speed);
    }
    
    void Forward()//‘Oi‚·‚é
    {

    }
}
