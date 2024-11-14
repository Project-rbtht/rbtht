using UnityEngine;

public class SEPlayer : MonoBehaviour
{
    // Inspector�Őݒ�\�ɂ��邽�߂�public�ɂ���
    public AudioClip seClip;         // �Đ�����T�E���h�G�t�F�N�g
    public float interval = 5f;      // SE���Đ�����Ԋu�i�b�j

    private AudioSource audioSource; // AudioSource�R���|�[�l���g

    void Start()
    {
        // AudioSource��ǉ��܂��͎擾
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = seClip;

        // ���[�v���J�n
        StartCoroutine(PlaySEWithInterval());
    }

    // SE���w�肵���Ԋu�ōĐ�����R���[�`��
    private System.Collections.IEnumerator PlaySEWithInterval()
    {
        while (true)
        {
            audioSource.Play();  // SE���Đ�
            yield return new WaitForSeconds(interval);  // �w�肵���Ԋu�ҋ@
        }
    }
}
