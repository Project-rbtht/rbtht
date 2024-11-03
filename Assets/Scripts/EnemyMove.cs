using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; // ウェイポイント
    [SerializeField] private GameObject groundBreakPrefab; // 弾のプレハブ
    [SerializeField] private float speed = 2f; // 移動速度
    [SerializeField] private float fireRate = 2f; // 弾を発射する間隔
    [SerializeField] private float yPosition = 0f; // 保持するY座標

    private int currentWaypointIndex = 0;
    private float nextFireTime = 0f;

    private void Update()
    {
        if (waypoints.Length == 0) return; // ウェイポイントがない場合は何もしない

        // Y座標を固定
        Vector2 targetPosition = new Vector2(
            waypoints[currentWaypointIndex].transform.position.x,
            yPosition
        );

        // 移動
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);

        // ウェイポイントに到達したら次へ
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0; // リセット
            }
        }

        // 弾を発射
        if (Time.time >= nextFireTime)
        {
            FireGroundBreak();
            nextFireTime = Time.time + fireRate; // 次の発射時間を設定
        }
    }

    private void FireGroundBreak()
    {
        if (groundBreakPrefab != null)
        {
            // 弾を発射
            Instantiate(groundBreakPrefab, transform.position, Quaternion.identity);
        }
    }
}