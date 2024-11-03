using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // ’e‚ÌPrefab
    public float bulletSpeed = 10f; // ’e‚Ì‘¬“x
    public float bulletLifeTime = 2f; // ’e‚ÌÁ–Å‚Ü‚Å‚ÌŠÔ
    public float spawnInterval = 1f; // ’e‚Ì¶¬ŠÔŠu

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
            rb.velocity = transform.up * bulletSpeed; // ã•ûŒü‚É”ò‚Î‚·
        }

        // ˆê’èŠÔŒã‚É’e‚ğÁ–Å‚³‚¹‚é
        Destroy(bullet, bulletLifeTime);
    }
}
