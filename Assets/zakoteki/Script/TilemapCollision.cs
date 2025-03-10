using UnityEngine;

public class TilemapCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 弾がTilemapに当たったときの処理
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject); // Tilemapを消滅させる
        }
    }
}