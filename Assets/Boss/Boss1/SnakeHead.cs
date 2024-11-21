using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : BossBase
{
    public GameObject bullet;
    private float laserLength = 20;
    private bool open = false;
    private Animator anim;//アニメーター
    private bool moveBool = false;//これがtrueのときだけ移動
    private GameObject player;
    private Vector3 movePoint;//移動先の指定
    public float speed = 10;//速度
    private Transform playerPos;//プレイヤーの位置
    private PlayerScript playerScript;
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
        yield return new WaitForSeconds(0.5f);
        Instantiate(bullet, transform.position + laserLength * transform.right, transform.rotation);
        yield return new WaitForSeconds(4.5f);
        open = false;
        yield return new WaitForSeconds(1);
        StartCoroutine(ChooseAction());
    }

    private IEnumerator MovePlayerHight()
    {
        movePoint = new Vector3(transform.position.x, playerPos.position.y, transform.position.z);//y座標だけplayerの位置に移動
        moveBool = true;
        yield return new WaitForSeconds(2);
        moveBool = false;
        StartCoroutine(LaserSpawn());
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
        StartCoroutine(MovePlayerHight());
        //StartCoroutine(LaserSpawn());
        yield return new WaitForSeconds(0);
    }
   public override void Death()
    {
        gameManager_Boss1.LeftSnakeDead();
        Destroy(this.gameObject);
        UnityEngine.Debug.Log("Left Death");
    }
}
