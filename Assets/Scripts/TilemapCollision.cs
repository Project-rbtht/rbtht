using UnityEngine;

public class TilemapCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �e��Tilemap�ɓ��������Ƃ��̏���
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject); // Tilemap�����ł�����
        }
    }
}