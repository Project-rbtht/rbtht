using UnityEngine;

public class AnimationRepeater : MonoBehaviour
{
    // Inspectorで設定可能にするためにpublicにする
    public float interval = 5f;         // アニメーションを再生する間隔（秒）
    public AnimationClip animationClip; // 出現させるアニメーション

    private Animator animator;          // Animatorコンポーネント
    private bool isPlayingAnimation = false; // アニメーションが再生中かどうかを確認

    void Start()
    {
        // Animatorコンポーネントを取得
        animator = GetComponent<Animator>();

        // ループを開始
        StartCoroutine(PlayAnimationWithInterval());
    }

    // アニメーションを指定した間隔で再生するコルーチン
    private System.Collections.IEnumerator PlayAnimationWithInterval()
    {
        while (true)
        {
            // アニメーションが指定されている場合、再生する
            if (animationClip != null && animator != null && !isPlayingAnimation)
            {
                isPlayingAnimation = true;
                animator.Play(animationClip.name);  // アニメーションを再生
            }

            yield return new WaitForSeconds(interval);  // 指定した間隔待機
        }
    }
}
