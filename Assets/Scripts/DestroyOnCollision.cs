using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public GameObject targetObject; // ���ł�����ΏۃI�u�W�F�N�g

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �Փ˂����I�u�W�F�N�g���w�肳�ꂽ�I�u�W�F�N�g�ƈ�v���邩�m�F
        if (collision.gameObject == targetObject)
        {
            Destroy(gameObject); // ���̃I�u�W�F�N�g�����ł�����
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // �g���K�[�ŐG�ꂽ�I�u�W�F�N�g���w�肳�ꂽ�I�u�W�F�N�g�ƈ�v���邩�m�F
        if (other.gameObject == targetObject)
        {
            Destroy(gameObject); // ���̃I�u�W�F�N�g�����ł�����
        }
    }
}
