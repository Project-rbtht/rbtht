using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockOnArea : MonoBehaviour
{
    private GameObject player;
    public float damageRadius = 5.0f; // ダメージを与える範囲の半径
    public float damageInterval = 1.0f; // ダメージを与える間隔（秒）
    public int damageAmount = 10; // 与えるダメージ量
    private bool playerInZone = false; // プレイヤーが範囲内にいるかどうか
    public int damageValue = 1;
    public Collider2D col;

    void Start()
    {
        player = GameObject.Find("PlayerObject");
        if (player == null)
        {
            Debug.Log("player == null");
        }
        else
        {
            StartCoroutine(EnableDamage());
        }
    }

    private IEnumerator EnableDamage()
    {
        yield return new WaitForSeconds(1);
        col.enabled = true;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null)
            {
                damageTarget.Damage(damageValue);
            }
        }
    }
}
