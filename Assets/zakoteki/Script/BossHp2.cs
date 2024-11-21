using UnityEngine;

public class BossHp2 : MonoBehaviour, Idamagable
{
    public int hp = 5;
    public int attackDamage = 2;
    private Animator anim;
    public string targetScene = "afterScene"; // �J�ڐ�V�[���̖��O
    private PlayerScript playerScript; // PlayerScript�ւ̎Q��

    // �_���[�W���̐ݒ�
    public AudioClip damageSound; // �_���[�W�����w��
    private AudioSource audioSource; // �I�[�f�B�I�\�[�X�R���|�[�l���g

    void Start()
    {
        anim = GetComponent<Animator>();

        // "Player" �^�O���t����GameObject����PlayerScript���擾
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerScript = player.GetComponent<PlayerScript>();
        }

        // �I�[�f�B�I�\�[�X�̏�����
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

        // �_���[�W�����Đ�
        if (damageSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(damageSound);
        }

        crack();
        if (hp <= 0)
        {
            Debug.Log("hp = " + hp);

            // �{�X���|�ꂽ�Ƃ��Ƀv���C���[�ɃA�r���e�B��t�^
            if (playerScript != null)
            {
                playerScript.GetAbility(2); // ��Ƃ���2�i����̃A�r���e�B�j��t�^
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
