using UnityEngine;

public class BossHp2 : MonoBehaviour, Idamagable
{
    public int hp = 5;
    public int attackDamage = 2;
    private Animator anim;
    public string targetScene = "afterScene"; // 遷移先シーンの名前
    private PlayerScript playerScript; // PlayerScriptへの参照

    // ダメージ音の設定
    public AudioClip damageSound; // ダメージ音を指定
    private AudioSource audioSource; // オーディオソースコンポーネント

    void Start()
    {
        anim = GetComponent<Animator>();

        // "Player" タグが付いたGameObjectからPlayerScriptを取得
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerScript = player.GetComponent<PlayerScript>();
        }

        // オーディオソースの初期化
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void crack()
    {
        if (hp <= 2)
        {
            anim.SetBool("crack", true);
        }
    }

    public void Damage(int damage)
    {
        hp -= damage;

        // ダメージ音を再生
        if (damageSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(damageSound);
        }

        crack();
        if (hp <= 0)
        {
            Debug.Log("hp = " + hp);

            // ボスが倒れたときにプレイヤーにアビリティを付与
            if (playerScript != null)
            {
                playerScript.GetAbility(2); // 例として2（特定のアビリティ）を付与
            }

            // 指定したシーンに遷移
            LoadScene();
            Destroy(this.gameObject); // ボスを消滅させる
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Idamagable>().Damage(attackDamage);
        }
    }

    private void LoadScene()
    {
        FadeManager.Instance.LoadScene(targetScene, 1.0f); // 1.0f はフェードの時間
    }
}
