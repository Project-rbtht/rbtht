using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // �ړ�����V�[���̖��O���w��
    [SerializeField] private string targetScene = "TargetSceneName"; // �J�ڐ�̃V�[������Inspector�Őݒ�
    [SerializeField] private KeyCode switchKey = KeyCode.Space; // �J�ڂɎg�p����L�[���w��i�f�t�H���g��Space�L�[�j

    void Update()
    {
        // �w�肵���L�[�������ꂽ�ꍇ�ɃV�[����؂�ւ���
        if (Input.GetKeyDown(switchKey))
        {
            LoadScene();
        }
    }

    // �V�[����ǂݍ��ޏ���
    private void LoadScene()
    {
        if (!string.IsNullOrEmpty(targetScene))
        {
            SceneManager.LoadScene(targetScene);
        }
        else
        {
            Debug.LogWarning("TargetScene���ݒ肳��Ă��܂���B");
        }
    }
}
