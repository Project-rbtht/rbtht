using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, Idamagable
{
    // Start is called before the first frame update
    public int healthPoint = 2;
    public int attack = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collision)
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
    }

    public void Death()
    {
        Destroy(this.gameObject);
        UnityEngine.Debug.Log("on Death");
    }
}
