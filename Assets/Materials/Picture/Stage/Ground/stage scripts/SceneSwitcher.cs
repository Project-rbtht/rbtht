using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // 移動するシーンの名前を指定
    [SerializeField] private string targetScene = "TargetSceneName"; // 遷移先のシーン名をInspectorで設定
    [SerializeField] private KeyCode switchKey = KeyCode.Space; // 遷移に使用するキーを指定（デフォルトはSpaceキー）

    void Update()
    {
        // 指定したキーが押された場合にシーンを切り替える
        if (Input.GetKeyDown(switchKey))
        {
            LoadScene();
        }
    }

    // シーンを読み込む処理
    private void LoadScene()
    {
        if (!string.IsNullOrEmpty(targetScene))
        {
            SceneManager.LoadScene(targetScene);
        }
        else
        {
            Debug.LogWarning("TargetSceneが設定されていません。");
        }
    }
}
