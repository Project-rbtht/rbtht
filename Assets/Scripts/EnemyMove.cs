using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; // �E�F�C�|�C���g
    [SerializeField] private GameObject groundBreakPrefab; // �e�̃v���n�u
    [SerializeField] private float speed = 2f; // �ړ����x
    [SerializeField] private float fireRate = 2f; // �e�𔭎˂���Ԋu
    [SerializeField] private float yPosition = 0f; // �ێ�����Y���W

    private int currentWaypointIndex = 0;
    private float nextFireTime = 0f;

    private void Update()
    {
        if (waypoints.Length == 0) return; // �E�F�C�|�C���g���Ȃ��ꍇ�͉������Ȃ�

        // Y���W���Œ�
        Vector2 targetPosition = new Vector2(
            waypoints[currentWaypointIndex].transform.position.x,
            yPosition
        );

        // �ړ�
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);

        // �E�F�C�|�C���g�ɓ��B�����玟��
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // ���Z�b�g
            }
        }

        // �e�𔭎�
        if (Time.time >= nextFireTime)
        {
            FireGroundBreak();
            nextFireTime = Time.time + fireRate; // ���̔��ˎ��Ԃ�ݒ�
        }
    }

    private void FireGroundBreak()
    {
        if (groundBreakPrefab != null)
        {
            // �e�𔭎�
            Instantiate(groundBreakPrefab, transform.position, Quaternion.identity);
        }
    }
}