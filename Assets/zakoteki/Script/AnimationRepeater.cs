using UnityEngine;

public class AnimationRepeater : MonoBehaviour
{
    // Inspector�Őݒ�\�ɂ��邽�߂�public�ɂ���
    public float interval = 5f;         // �A�j���[�V�������Đ�����Ԋu�i�b�j
    public AnimationClip animationClip; // �o��������A�j���[�V����

    private Animator animator;          // Animator�R���|�[�l���g
    private bool isPlayingAnimation = false; // �A�j���[�V�������Đ������ǂ������m�F

    void Start()
    {
        // Animator�R���|�[�l���g���擾
        animator = GetComponent<Animator>();

        // ���[�v���J�n
        StartCoroutine(PlayAnimationWithInterval());
    }

    // �A�j���[�V�������w�肵���Ԋu�ōĐ�����R���[�`��
    private System.Collections.IEnumerator PlayAnimationWithInterval()
    {
        while (true)
        {
            // �A�j���[�V�������w�肳��Ă���ꍇ�A�Đ�����
            if (animationClip != null && animator != null && !isPlayingAnimation)
            {
                isPlayingAnimation = true;
                animator.Play(animationClip.name);  // �A�j���[�V�������Đ�
            }

            yield return new WaitForSeconds(interval);  // �w�肵���Ԋu�ҋ@
        }
    }
}
