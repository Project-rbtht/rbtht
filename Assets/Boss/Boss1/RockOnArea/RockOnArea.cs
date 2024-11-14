using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockOnArea : MonoBehaviour
{
    private GameObject player;
    public float damageRadius = 5.0f; // �_���[�W��^����͈͂̔��a
    public float damageInterval = 1.0f; // �_���[�W��^����Ԋu�i�b�j
    public int damageAmount = 10; // �^����_���[�W��
    private bool playerInZone = false; // �v���C���[���͈͓��ɂ��邩�ǂ���
    public int damageValue = 1;
    public Collider2D col;
    private Animator anim;//�A�j���[�^�[
    private int state = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("PlayerObject");
        if (player == null)
        {
            Debug.Log("player == null");
        }
        else
        {
            StartCoroutine(EnableDamage());
        }
    }

    void Update()
    {
        anim.SetInteger("state", state);
    }

        private IEnumerator EnableDamage()
    {
        yield return new WaitForSeconds(0.9f);
        state = 1;
        anim.SetInteger("state", 1);
        yield return new WaitForSeconds(0.1f);
        col.enabled = true;
        state = 2;
        anim.SetInteger("state", 2);
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null)
            {
                damageTarget.Damage(damageValue);
            }
        }
    }
}
