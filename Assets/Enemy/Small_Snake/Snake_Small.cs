using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_Small : EnemyBase //���ӂPEnemyBase�̌p����Monobehaviour������
{
    // Start is called before the first frame update
    private bool goToPlayer;
    void Start()
    {
        base.Start();//���ӂQ���̍s�𑫂�
        Debug.Log("Snake_Small Start keisyouTest");
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();//���ӂR���̍s������
        FlipToPlayer();
        Debug.Log("Snake_Small Update keisyouTest");

        rigidbody2d.AddForce(transform.right * speed);
    }
    
    void Forward()//�O�i����
    {

    }
}
