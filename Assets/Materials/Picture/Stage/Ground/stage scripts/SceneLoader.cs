using UnityEngine;
using UnityEngine.SceneManagement; // 忘れない！！
public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string scene0)
    {
        FadeManager.Instance.LoadScene(scene0, 1.0f);
    }
}