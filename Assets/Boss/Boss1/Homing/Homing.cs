using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    private GameObject player;
    private Transform playerPos;
    public float speed = 10; // 速度
    protected Rigidbody2D rigidbody2d;
    public float lifetime = 5.0f; // 弾の寿命
    public float firstForce = 10;//弾に最初に加える力

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("PlayerObject");
        if (player == null)
        {
            Debug.Log("player == null");
        }
        playerPos = player.transform;

        rigidbody2d.AddForce(transform.right * firstForce, ForceMode2D.Impulse);
        // 一定時間後に弾を消滅させるコルーチンを開始
        StartCoroutine(DestroyAfterTime(lifetime));
    }

    void Update()
    {
        // プレイヤーの位置に向かって移動
        float dist = Vector3.Distance(transform.position, player.transform.position);
        Vector3 chaseVector = (player.transform.position - transform.position) / dist;
        rigidbody2d.AddForce(chaseVector * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // プレイヤーに当たった場合、ダメージを与える
        if (collision.gameObject == player)
        {
            Idamagable damageable = player.GetComponent<Idamagable>();
            if (damageable != null)
            {
                damageable.Damage(10); // ダメージ量は10に設定（必要に応じて変更）
            }

            // 弾を消滅させる
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        // 指定した時間後に弾を消滅させる
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}