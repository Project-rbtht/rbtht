using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // ’e‚ÌPrefab
    public float bulletSpeed = 10f; // ’e‚Ì‘¬“x
    public float bulletLifeTime = 2f; // ’e‚ÌÁ–Å‚Ü‚Å‚ÌŠÔ
    public float spawnInterval = 1f; // ’e‚Ì¶¬ŠÔŠu
    public Vector2 bulletDirection = Vector2.up; // ’e‚ğ”ò‚Î‚·•ûŒüiƒfƒtƒHƒ‹ƒg‚Íã•ûŒüj

    private void Start()
    {
        StartCoroutine(SpawnBullets());
    }

    private IEnumerator SpawnBullets()
    {
        while (true)
        {
            SpawnBullet();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnBullet()
    {
        // ’e‚ğ¶¬
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // ’e‚Ì‘¬“x‚ğİ’è
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = bulletDirection.normalized * bulletSpeed; // w’è•ûŒü‚É”ò‚Î‚·
        }

        // ˆê’èŠÔŒã‚É’e‚ğÁ–Å‚³‚¹‚é
        Destroy(bullet, bulletLifeTime);
    }

    // ’e‚Ì•ûŒü‚ğŠO•”‚©‚çİ’è‚·‚éƒƒ\ƒbƒh
    public void SetBulletDirection(Vector2 direction)
    {
        bulletDirection = direction.normalized; // ³‹K‰»‚µ‚Äİ’è
    }
}
