using UnityEngine;

public class SEPlayer : MonoBehaviour
{
    // Inspectorで設定可能にするためにpublicにする
    public AudioClip seClip;         // 再生するサウンドエフェクト
    public float interval = 5f;      // SEを再生する間隔（秒）

    private AudioSource audioSource; // AudioSourceコンポーネント

    void Start()
    {
        // AudioSourceを追加または取得
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = seClip;

        // ループを開始
        StartCoroutine(PlaySEWithInterval());
    }

    // SEを指定した間隔で再生するコルーチン
    private System.Collections.IEnumerator PlaySEWithInterval()
    {
        while (true)
        {
            audioSource.Play();  // SEを再生
            yield return new WaitForSeconds(interval);  // 指定した間隔待機
        }
    }
}
