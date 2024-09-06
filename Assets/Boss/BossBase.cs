using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : MonoBehaviour, IDamageable
{
    // Start is called before the first frame update
    public int healthPoint = 2;
    public int attack = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int value)//�_���[�W����
    {
        UnityEngine.Debug.Log("on Damage");
        healthPoint -= value;//HP��value�̂Ԃ񂾂����炷
        if (healthPoint <= 0)
        {//HP��0�ȉ��ɂȂ����玀
            Death();
        }
    }

    public void Death()
    {
        Destroy(this.gameObject);
        UnityEngine.Debug.Log("on Death");
    }
}
