using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // �e��Prefab
    public float bulletSpeed = 10f; // �e�̑��x
    public float bulletLifeTime = 2f; // �e�̏��ł܂ł̎���
    public float spawnInterval = 1f; // �e�̐����Ԋu
    public Vector2 bulletDirection = Vector2.up; // �e���΂������i�f�t�H���g�͏�����j

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
            rb.velocity = bulletDirection.normalized * bulletSpeed; // �w������ɔ�΂�
        }

        // ��莞�Ԍ�ɒe�����ł�����
        Destroy(bullet, bulletLifeTime);
    }

    // �e�̕������O������ݒ肷�郁�\�b�h
    public void SetBulletDirection(Vector2 direction)
    {
        bulletDirection = direction.normalized; // ���K�����Đݒ�
    }
}
