using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // �e��Prefab
    public float bulletSpeed = 10f; // �e�̑��x
    public float bulletLifeTime = 2f; // �e�̏��ł܂ł̎���
    public float spawnInterval = 1f; // �e�̐����Ԋu

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
        // �e�𐶐�
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // �e�̑��x��ݒ�
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.up * bulletSpeed; // ������ɔ�΂�
        }

        // ��莞�Ԍ�ɒe�����ł�����
        Destroy(bullet, bulletLifeTime);
    }
}
