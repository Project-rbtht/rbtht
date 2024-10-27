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

    void Start()
    {
        player = GameObject.Find("PlayerObject");
        if (player == null)
        {
            Debug.Log("player == null");
        }
        else
        {
            // �v���C���[���͈͓��ɂ��邩�ǂ��������I�Ɋm�F
            StartCoroutine(CheckPlayerInZone());
        }
    }

    IEnumerator CheckPlayerInZone()
    {
        while (true)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

            // �v���C���[���_���[�W�͈͓��ɂ��邩�`�F�b�N
            if (distanceToPlayer <= damageRadius)
            {
                if (!playerInZone)
                {
                    playerInZone = true;
                    StartCoroutine(DealDamageToPlayer());
                }
            }
            else
            {
                playerInZone = false; // �͈͊O�ɏo���ꍇ�A�_���[�W���~
            }

            yield return new WaitForSeconds(0.1f); // �`�F�b�N�̊Ԋu
        }
    }

    IEnumerator DealDamageToPlayer()
    {
        while (playerInZone)
        {
            // �v���C���[�Ƀ_���[�W��^����
            IDamageable damageable = player.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(damageAmount);
            }

            // ���̃_���[�W�܂őҋ@
            yield return new WaitForSeconds(damageInterval);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // �G�f�B�^�[��Ń_���[�W�͈͂����o��
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, damageRadius);
    }
}
