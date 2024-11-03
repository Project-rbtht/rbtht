using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public GameObject targetObject; // 消滅させる対象オブジェクト

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したオブジェクトが指定されたオブジェクトと一致するか確認
        if (collision.gameObject == targetObject)
        {
            Destroy(gameObject); // このオブジェクトを消滅させる
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // トリガーで触れたオブジェクトが指定されたオブジェクトと一致するか確認
        if (other.gameObject == targetObject)
        {
            Destroy(gameObject); // このオブジェクトを消滅させる
        }
    }
}
