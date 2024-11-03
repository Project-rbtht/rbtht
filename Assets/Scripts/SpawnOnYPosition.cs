using UnityEngine;

public class SpawnOnYPosition : MonoBehaviour
{
    public float targetYPosition; // 到達すべきy座標
    private bool hasSpawned = false; // すでに出現したかどうかのフラグ

    void Start()
    {
        // 最初にオブジェクトを非表示にする
        gameObject.SetActive(false);
    }

    void Update()
    {
        // PlayerObjectの位置を取得
        GameObject player = GameObject.FindWithTag("Player"); // PlayerObjectのタグが「Player」であることを想定
        if (player != null)
        {
            // Playerのy座標が指定したy座標を超えた場合
            if (player.transform.position.y >= targetYPosition && !hasSpawned)
            {
                SpawnObject();
                hasSpawned = true; // 出現済みにする
            }
        }
    }

    void SpawnObject()
    {
        // 自身を出現させる
        gameObject.SetActive(true);
    }
}
