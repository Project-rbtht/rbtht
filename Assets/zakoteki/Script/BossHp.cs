using UnityEngine;

public class BossHp : MonoBehaviour, Idamagable
{
    public int hp = 5;
    public int attackDamage = 2;
    private Animator anim;

    // シーン遷移時に移動するターゲットシーンの名前を指定
    public string targetScene = "afterScene"; // 遷移先シーンの名前（適宜変更）

    void Start()
    {
        this.anim = GetComponent<Animator>();
        

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
            // HPが0になった場合、指定したシーンに遷移
            LoadScene();
            Destroy(this.gameObject); // 敵を消滅させる
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Idamagable>().Damage(attackDamage);
        }
    }

    // 指定したシーンに遷移するメソッド
    private void LoadScene()
    {
        // FadeManagerを使って、シーンを指定して遷移
        FadeManager.Instance.LoadScene(targetScene, 1.0f); // 1.0f はフェードの時間
    }
}
