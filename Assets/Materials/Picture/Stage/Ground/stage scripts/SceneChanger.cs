using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // �w�肵���b����ɃV�[�����ړ�
    public float delayTime = 5.0f;

    // �ړ���̃V�[����
    public string sceneName;

    void Start()
    {
        // �w��b����ɃV�[����ǂݍ���
        Invoke("ChangeScene", delayTime);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
