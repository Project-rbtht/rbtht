using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead_right : BossBase
{
    public GameObject bullet;
    private float mouthPos = 2;
    private bool open = false;
    private Animator anim;//アニメーター
    private bool moveBool = false;//これがtrueのときだけ移動
    private GameObject player;
    private Vector3 movePoint;//移動先の指定
    public float speed = 10;//速度
    private Transform playerPos;//プレイヤーの位置
    private int action = 0;//現在どの行動パターンか
    public GameObject damageArea;
    public GameManager_Boss1 gameManager_Boss1;
    // Start is called before the first frame update
    void Start()
    {
        this.anim = GetComponent<Animator>();
        player = GameObject.Find("PlayerObject");
        if (player == null)
        {
            Debug.Log("player == null");
        }
        playerPos = player.transform;
        StartCoroutine(ChooseAction());
        //StartCoroutine(LaserSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Open", open);
        if (moveBool) {
            transform.position = Vector3.MoveTowards(transform.position, movePoint, speed * Time.deltaTime);
        }
    }

    private IEnumerator LaserSpawn()//頭の向き（transform.right）にレーザーを放つ
    {
        open = true;
        yield return new WaitForSeconds(1.5f);
        Instantiate(bullet, transform.position + mouthPos * transform.right, transform.rotation);
        yield return new WaitForSeconds(4.5f);
        open = false;
        yield return new WaitForSeconds(1);
        StartCoroutine(ChooseAction());
    }

    private IEnumerator MovePlayerHight()
    {
        movePoint = new Vector3(transform.position.x, playerPos.position.y, transform.position.z);//y座標だけplayerの位置に移動
        moveBool = true;
        yield return new WaitForSeconds(1.5f);
        moveBool = false;
        StartCoroutine(LaserSpawn());
    }

   private IEnumerator SpawnRockOnArea()
    {
        open = true;
        yield return new WaitForSeconds(0.5f);
        Instantiate(damageArea, playerPos.position, transform.rotation);
        yield return new WaitForSeconds(1.5f);
        open = false;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(ChooseAction());
    }


    /*
    private IEnumerator PlayerHightLaser()
    {
        StartCoroutine(MovePlayerHight());
        StartCoroutine(LaserSpawn());
    }
    */

    private IEnumerator ChooseAction()
    {
        //LaserSpawn();
        action = Random.Range(1, 3);
        if (action <= 1)
        {
            StartCoroutine(MovePlayerHight());
        }else if(action <= 2)
        {
            StartCoroutine(SpawnRockOnArea());
        }
        //StartCoroutine(LaserSpawn());
        yield return new WaitForSeconds(0);
    }
    public override void Death()
    {
        gameManager_Boss1.RightSnakeDead();
        Destroy(this.gameObject);
        UnityEngine.Debug.Log("Right Death");
    }
}
