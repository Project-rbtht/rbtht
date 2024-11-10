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

    void Start()
    {
        player = GameObject.Find("PlayerObject");
        if (player == null)
        {
            Debug.Log("player == null");
        }
        else
        {
            // プレイヤーが範囲内にいるかどうかを定期的に確認
            StartCoroutine(CheckPlayerInZone());
        }
    }

    IEnumerator CheckPlayerInZone()
    {
        while (true)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            // プレイヤーがダメージ範囲内にいるかチェック
            if (distanceToPlayer <= damageRadius)
            {
                if (!playerInZone)
                {
                    playerInZone = true;
                    StartCoroutine(DealDamageToPlayer());
                }
            }
            else
            {
                playerInZone = false; // 範囲外に出た場合、ダメージを停止
            }

            yield return new WaitForSeconds(0.1f); // チェックの間隔
        }
    }

    IEnumerator DealDamageToPlayer()
    {
        while (playerInZone)
        {
            // プレイヤーにダメージを与える
            IDamageable damageable = player.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(damageAmount);
            }

            // 次のダメージまで待機
            yield return new WaitForSeconds(damageInterval);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // エディター上でダメージ範囲を視覚化
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, damageRadius);
    }
}
