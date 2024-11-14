using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : BossBase
{
    public GameObject bullet;
    private float laserLength = 20;
    private bool open = false;
    private Animator anim;//�A�j���[�^�[
    private bool moveBool = false;//���ꂪtrue�̂Ƃ������ړ�
    private GameObject player;
    private Vector3 movePoint;//�ړ���̎w��
    public float speed = 10;//���x
    private Transform playerPos;//�v���C���[�̈ʒu
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

    private IEnumerator LaserSpawn()//���̌����itransform.right�j�Ƀ��[�U�[�����
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
        movePoint = new Vector3(transform.position.x, playerPos.position.y, transform.position.z);//y���W����player�̈ʒu�Ɉړ�
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
