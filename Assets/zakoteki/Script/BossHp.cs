using UnityEngine;

public class BossHp : MonoBehaviour, Idamagable
{
    public int hp = 5;
    public int attackDamage = 2;
    private Animator anim;

    // �V�[���J�ڎ��Ɉړ�����^�[�Q�b�g�V�[���̖��O���w��
    public string targetScene = "afterScene"; // �J�ڐ�V�[���̖��O�i�K�X�ύX�j

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
            // HP��0�ɂȂ����ꍇ�A�w�肵���V�[���ɑJ��
            LoadScene();
            Destroy(this.gameObject); // �G�����ł�����
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Idamagable>().Damage(attackDamage);
        }
    }

    // �w�肵���V�[���ɑJ�ڂ��郁�\�b�h
    private void LoadScene()
    {
        // FadeManager���g���āA�V�[�����w�肵�đJ��
        FadeManager.Instance.LoadScene(targetScene, 1.0f); // 1.0f �̓t�F�[�h�̎���
    }
}
