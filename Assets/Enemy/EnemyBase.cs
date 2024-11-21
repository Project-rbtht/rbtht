using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour, Idamagable
{
    // Start is called before the first frame update
    public int healthPoint = 5;//�̗�
    public int attack = 1;//�U����
    public float nockBackForce = 10;
    protected Rigidbody2D rigidbody2d;
    protected GameObject player;//�v���C���[�̏����g����悤�ɂ��Ă���
    public float speed = 10;//�ړ����x
    protected void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();//���g��Rigidbody��ϐ��ɓ����
        player = GameObject.Find("PlayerObject");
        Debug.Log("EnemyBase Start keisyouTest");
    }
    protected void FlipToPlayer()//Player�̕�������
    {
        if (player.transform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // Update is called once per frame
    protected void Update()
    {
        Debug.Log("EnemyBase Update keisyouTest");
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null)
            {
                damageTarget.Damage(attack);
            }
        }
    }
    public void Damage(int value)//�_���[�W����
    {
        UnityEngine.Debug.Log("on Damage");
        healthPoint -= value;//HP��value�̂Ԃ񂾂����炷
        Debug.Log("hp = " + healthPoint);
        if (healthPoint <= 0)
        {//HP��0�ȉ��ɂȂ����玀
            Death();
        }
        else
        {
            NockBack();//�m�b�N�o�b�N
        }
    }
    protected void NockBack()//�m�b�N�o�b�N(�m�b�N�o�b�N�̏�����ς�������Ί֐��̃I�[�o�[���C�h������)
    {
        rigidbody2d.velocity = new Vector3(0,0,0);
        float dist = Vector3.Distance(transform.position, player.transform.position);
        Vector3 nockBackVector = (transform.position - player.transform.position) / dist;
        rigidbody2d.AddForce(nockBackVector * nockBackForce, ForceMode2D.Impulse);
    }

    public void Death()
    {
        Destroy(this.gameObject);
        UnityEngine.Debug.Log("on Death");
    }
}
