using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : MonoBehaviour, Idamagable
{
    // Start is called before the first frame update
    public int healthPoint = 20;
    public int attack = 1;
    private SpriteRenderer spriteRenderer;
    public float flashDuration = 0.1f; // �_�ł���ۂ̔����Ȃ鎞��
    public int flashCount = 4; // �_�ŉ�
    public float flashInterval = 0.5f; // �_�ł̊Ԋu�i�����猳�̐F�ɖ߂�Ԋu�j
    private Color originalColor;
    public GameObject damageEffect;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color; // ���̐F��ۑ�
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int value)//�_���[�W����
    {
        UnityEngine.Debug.Log("on Damage");
        healthPoint -= value;//HP��value�̂Ԃ񂾂����炷
        Instantiate(damageEffect, transform.position, transform.rotation);
        Debug.Log("hp = " + healthPoint);
        if (healthPoint <= 0)
        {//HP��0�ȉ��ɂȂ����玀
            Death();
        }
        else
        {
            StartCoroutine(FlashWhiteMultipleTimes());
        }
    }

    IEnumerator FlashWhiteMultipleTimes()
    {
        for (int i = 0; i < flashCount; i++)
        {
            // �X�v���C�g�𔒂ɕύX
            spriteRenderer.color = Color.black;

            // �����̊Ԕ��������܂܂ɂ���
            yield return new WaitForSeconds(flashDuration);

            // ���̐F�ɖ߂�
            spriteRenderer.color = originalColor;

            // ���̓_�ł܂őҋ@
            yield return new WaitForSeconds(flashInterval);
        }
    }

    public virtual void Death()
    {
        Destroy(this.gameObject);
        UnityEngine.Debug.Log("on Death");
    }
}
