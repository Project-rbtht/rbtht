using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class DroneShot : MonoBehaviour
{
    public GameObject shellPrefab;
    public AudioClip sound;
    private int count;
 
    void Update()
    {
        count += 1;
 
        // （ポイント）
        // ６０フレームごとに砲弾を発射する
        if(count % 60 == 0)
        {
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            Rigidbody2D shellRb = shell.GetComponent<Rigidbody2D>();
 
            // 弾速
            shellRb.AddForce(transform.forward * 500);
 
 
            // ５秒後に砲弾を破壊する
            Destroy(shell, 5.0f);
        }
    }
}