using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // ���J�ϐ��Ƃ��ă^�[�Q�b�g�V�[���̖��O��ݒ�ł���悤�ɂ���
    public string targetScene = "after";

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // �^�[�Q�b�g�V�[���Ɉړ�����
            SceneManager.LoadScene(targetScene);
        }
    }
}