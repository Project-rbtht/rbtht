using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockOnArea : MonoBehaviour
{
    private GameObject player;
    public float damageRadius = 5.0f; // �_���[�W��^����͈͂̔��a
    public float damageInterval = 1.0f; // �_���[�W��^����Ԋu�i�b�j
    public int damageAmount = 10; // �^����_���[�W��
    private bool playerInZone = false; // �v���C���[���͈͓��ɂ��邩�ǂ���
    public int damageValue = 1;
    public Collider2D col;

    void Start()
    {
        player = GameObject.Find("PlayerObject");
        if (player == null)
        {
            Debug.Log("player == null");
        }
        else
        {
            StartCoroutine(EnableDamage());
        }
    }

    private IEnumerator EnableDamage()
    {
        yield return new WaitForSeconds(1);
        col.enabled = true;
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null)
            {
                damageTarget.Damage(damageValue);
            }
        }
    }
}
