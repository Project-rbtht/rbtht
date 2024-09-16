using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, Idamagable
{
    // Start is called before the first frame update
    public int healthPoint = 2;//�̗�
    public int attack = 1;//�U����
    public float nockBackForce = 10;
    private Rigidbody2D rigidbody2d;
    protected GameObject player;//�v���C���[�̏����g����悤�ɂ��Ă���
    protected void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();//���g��Rigidbody��ϐ��ɓ����
        player = GameObject.Find("PlayerObject");
        Debug.Log("EnemyBase Start keisyouTest");
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
        else//�m�b�N�o�b�N
        {
            float dist = Vector3.Distance(transform.position, player.transform.position);
            Vector3 nockBackVector = (transform.position - player.transform.position) / dist ;
            rigidbody2d.AddForce(nockBackVector * nockBackForce, ForceMode2D.Impulse);
        }
    }
    public void Death()
    {
        Destroy(this.gameObject);
        UnityEngine.Debug.Log("on Death");
    }
}
