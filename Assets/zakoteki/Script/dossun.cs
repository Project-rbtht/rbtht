using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dossun : MonoBehaviour
{   private Rigidbody2D rigid;
    private Vector2 moveDirection;
    private float moveSpeed;












 private void OnTriggerEnter2D(Collider2D collider)
 {
   //   Debug.Log("dosun");
        if(collider.gameObject.tag == "Player")
          {
   //         Debug.Log("TouchFloor");
            rigid.verocity = new Vector2(moveDirection.x * moveSpeed, rigid.verocity.y);
          }

}






}




















/*
{
    public float detectionRange = 100f; // プレイヤー検出範囲
    public float fallSpeed = 10f; // 落下速度
    public float damage = 1f; // プレイヤーダメージ
    public float fallDelay = 1f; // 落下までの遅延時間
    public LayerMask groundLayer; // 地面のレイヤー
    private bool isFalling = false;

    private Transform player;
    private Vector2 originalPosition; // 元の位置

    void Start()
    {
        // プレイヤーをタグで取得
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        originalPosition = transform.position; // 元の位置を記録
    }

    void Update()
    {
        // プレイヤーが近くにいるかチェック
        if (player != null && Vector2.Distance(transform.position, player.position) < detectionRange && !isFalling)
        {
            StartCoroutine(Fall());
        }
    }

    private System.Collections.IEnumerator Fall()
    {
        isFalling = true;
        
        // 落下までの遅延
        yield return new WaitForSeconds(fallDelay);

        // ドッスンが落ちるアニメーション
        while (true)
        {
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;

            // 地面に衝突したかチェック
            if (Physics2D.OverlapCircle(transform.position, 0.1f, groundLayer))
            {*/
      /*          // プレイヤーにダメージを与える
                if (player != null && Vector2.Distance(transform.position, player.position) < 1f) // ダメージ範囲
                {
                    PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                    if (playerHealth != null)
                    {
                        playerHealth.TakeDamage(damage);
                    }
                }

      */          // 元の位置に戻す
      /*          transform.position = originalPosition;
                isFalling = false;
                yield break;
            }

            yield return null;
        }
    }
}*/