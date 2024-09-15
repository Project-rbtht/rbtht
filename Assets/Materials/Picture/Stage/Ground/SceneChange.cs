using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // 公開変数としてターゲットシーンの名前を設定できるようにする
    public string targetScene = "after";

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // ターゲットシーンに移動する
            SceneManager.LoadScene(targetScene);
        }
    }
}