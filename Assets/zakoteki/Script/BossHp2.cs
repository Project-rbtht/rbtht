using UnityEngine;

public class BossHp2 : MonoBehaviour, Idamagable
{
    public int hp = 5;
    public int attackDamage = 2;
    private Animator anim;
    public string targetScene = "afterScene"; // 遷移先シーンの名前
    private PlayerScript playerScript; // PlayerScriptへの参照

    void Start()
    {
        anim = GetComponent<Animator>();
        // "Player" タグが付いたGameObjectからPlayerScriptを取得
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerScript = player.GetComponent<PlayerScript>();
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
        crack();
        if (hp <= 0)
        {
            Debug.Log("hp = " + hp);

            // ボスが倒れたときにプレイヤーにアビリティを付与
            if (playerScript != null)
            {
                playerScript.GetAbility(2); // 例として1（レーザーのアビリティ）を付与
                // もし複数のアビリティを同時に付与したい場合は、GetAbility(2)なども呼び出せます
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
