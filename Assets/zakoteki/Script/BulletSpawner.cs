using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のPrefab
    public float bulletSpeed = 10f; // 弾の速度
    public float bulletLifeTime = 2f; // 弾の消滅までの時間
    public float spawnInterval = 1f; // 弾の生成間隔
    public Vector2 bulletDirection = Vector2.up; // 弾を飛ばす方向（デフォルトは上方向）

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
        // 弾を生成
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // 弾の速度を設定
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = bulletDirection.normalized * bulletSpeed; // 指定方向に飛ばす
        }

        // 一定時間後に弾を消滅させる
        Destroy(bullet, bulletLifeTime);
    }

    // 弾の方向を外部から設定するメソッド
    public void SetBulletDirection(Vector2 direction)
    {
        bulletDirection = direction.normalized; // 正規化して設定
    }
}
