using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockOnArea : MonoBehaviour
{
    private GameObject player;
    public float damageRadius = 5.0f; // �_���[�W��^����͈͂̔��a
    public float damageInterval = 1.0f; // �_���[�W��^����Ԋu�i�b�j
    public int attack = 1; // �^����_���[�W��
    private bool applyDamage = false;
    public Collider2D col;

    void Start()
    {
        player = GameObject.Find("PlayerObject");
        if (player == null)
        {
            Debug.Log("player == null");
        }
        else
        {
            // �v���C���[���͈͓��ɂ��邩�ǂ��������I�Ɋm�F
            StartCoroutine(ApplyDamage());
        }
    }

    IEnumerator ApplyDamage()
    {
        yield return new WaitForSeconds(1.5f);
        col.enabled = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (applyDamage && (collision.gameObject.tag == "Player"))
        {
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null)
            {
                damageTarget.Damage(attack);
                applyDamage = false;
            }
        }
    }

}
