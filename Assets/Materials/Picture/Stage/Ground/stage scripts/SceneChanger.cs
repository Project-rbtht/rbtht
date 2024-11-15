using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // 指定した秒数後にシーンを移動
    public float delayTime = 5.0f;

    // 移動先のシーン名
    public string sceneName;

    void Start()
    {
        // 指定秒数後にシーンを読み込む
        Invoke("ChangeScene", delayTime);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
