using UnityEngine;
using UnityEngine.SceneManagement; // �Y��Ȃ��I�I
public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}