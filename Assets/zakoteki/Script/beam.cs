using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // Inspectorで設定可能にするためにpublicにする
    public GameObject objectToSpawn; // 生成するオブジェクト
    public float spawnInterval = 5f; // オブジェクトを生成する間隔（秒）
    public Vector3 spawnPosition;    // 生成位置

    void Start()
    {
        // コルーチンを開始して、指定した間隔でオブジェクトを生成
        StartCoroutine(SpawnObjectWithInterval());
    }

    // 指定した間隔でオブジェクトを生成するコルーチン
    private System.Collections.IEnumerator SpawnObjectWithInterval()
    {
        while (true)
        {
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity); // オブジェクトを生成
            yield return new WaitForSeconds(spawnInterval); // 指定した間隔待機
        }
    }
}
