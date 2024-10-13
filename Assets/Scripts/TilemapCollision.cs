using UnityEngine;

public class TilemapCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ’e‚ªTilemap‚É“–‚½‚Á‚½‚Æ‚«‚Ìˆ—
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject); // Tilemap‚ğÁ–Å‚³‚¹‚é
        }
    }
}