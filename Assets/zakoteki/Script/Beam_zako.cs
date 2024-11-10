using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zakoBeam : MonoBehaviour
{
   public int damage = 1;
    private bool on = false;
    private Animator anim;
    private float laserLength = 20.5f;
    public int recastTime = 1;

    void Start()
    {
        this.anim = GetComponent<Animator>();
        StartCoroutine(DelayCoroutine());
    }

    private IEnumerator DelayCoroutine()
    {
        yield return new WaitForSeconds(2);
        on = true;
        yield return new WaitForSeconds(2);
        on = false;
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        anim.SetBool("on", on);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && on)
        {
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null)
            {
                damageTarget.Damage(damage);
            }
        }
    }
}
