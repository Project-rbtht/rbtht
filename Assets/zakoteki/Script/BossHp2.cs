using UnityEngine;

public class BossHp2 : MonoBehaviour, Idamagable
{
    public int hp = 5;
    public int attackDamage = 2;
    private Animator anim;
    public string targetScene = "afterScene"; // �J�ڐ�V�[���̖��O
    private PlayerScript playerScript; // PlayerScript�ւ̎Q��

    void Start()
    {
        anim = GetComponent<Animator>();
        // "Player" �^�O���t����GameObject����PlayerScript���擾
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

            // �{�X���|�ꂽ�Ƃ��Ƀv���C���[�ɃA�r���e�B��t�^
            if (playerScript != null)
            {
                playerScript.GetAbility(2); // ��Ƃ���1�i���[�U�[�̃A�r���e�B�j��t�^
                // ���������̃A�r���e�B�𓯎��ɕt�^�������ꍇ�́AGetAbility(2)�Ȃǂ��Ăяo���܂�
            }

            // �w�肵���V�[���ɑJ��
            LoadScene();
            Destroy(this.gameObject); // �{�X�����ł�����
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
        FadeManager.Instance.LoadScene(targetScene, 1.0f); // 1.0f �̓t�F�[�h�̎���
    }
}
