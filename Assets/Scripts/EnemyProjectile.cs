using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 10f; // 移動速度
    public Vector2 direction;  // 移動方向

    void Start()
    {
        // 移動方向を正規化する
        direction.Normalize();
    }

    void Update()
    {
        // 指定した速度で移動
        transform.Translate(direction * speed * Time.deltaTime);

        // 画面外に出たら自動的に削除する（例）
        if (transform.position.magnitude > 20f)
        {
            Destroy(gameObject);
        }
    }
}
