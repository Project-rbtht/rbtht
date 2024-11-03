using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 10f; // �ړ����x
    public Vector2 direction;  // �ړ�����

    void Start()
    {
        // �ړ������𐳋K������
        direction.Normalize();
    }

    void Update()
    {
        // �w�肵�����x�ňړ�
        transform.Translate(direction * speed * Time.deltaTime);

        // ��ʊO�ɏo���玩���I�ɍ폜����i��j
        if (transform.position.magnitude > 20f)
        {
            Destroy(gameObject);
        }
    }
}
