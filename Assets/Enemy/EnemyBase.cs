using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, Idamagable
{
    // Start is called before the first frame update
    public int healthPoint = 2;//体力
    public int attack = 1;//攻撃力
    public float nockBackForce = 10;
    private Rigidbody2D rigidbody2d;
    protected GameObject player;//プレイヤーの情報を使えるようにしておく
    protected void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();//自身のRigidbodyを変数に入れる
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
    public void Damage(int value)//ダメージ処理
    {
        UnityEngine.Debug.Log("on Damage");
        healthPoint -= value;//HPをvalueのぶんだけ減らす
        Debug.Log("hp = " + healthPoint);
        if (healthPoint <= 0)
        {//HPが0以下になったら死
            Death();
        }
        else//ノックバック
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
