using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{
    private GameObject player;
    private Transform playerPos;
    public float speed = 10; // ���x
    protected Rigidbody2D rigidbody2d;
    public float lifetime = 5.0f; // �e�̎���
    public float firstForce = 10;//�e�ɍŏ��ɉ������

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("PlayerObject");
        if (player == null)
        {
            Debug.Log("player == null");
        }
        playerPos = player.transform;

        rigidbody2d.AddForce(transform.right * firstForce, ForceMode2D.Impulse);
        // ��莞�Ԍ�ɒe�����ł�����R���[�`�����J�n
        StartCoroutine(DestroyAfterTime(lifetime));
    }

    void Update()
    {
        // �v���C���[�̈ʒu�Ɍ������Ĉړ�
        float dist = Vector3.Distance(transform.position, player.transform.position);
        Vector3 chaseVector = (player.transform.position - transform.position) / dist;
        rigidbody2d.AddForce(chaseVector * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �v���C���[�ɓ��������ꍇ�A�_���[�W��^����
        if (collision.gameObject == player)
        {
            Idamagable damageable = player.GetComponent<Idamagable>();
            if (damageable != null)
            {
                damageable.Damage(10); // �_���[�W�ʂ�10�ɐݒ�i�K�v�ɉ����ĕύX�j
            }

            // �e�����ł�����
            Destroy(gameObject);
        }
    }

    private IEnumerator DestroyAfterTime(float time)
    {
        // �w�肵�����Ԍ�ɒe�����ł�����
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}