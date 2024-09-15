using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update

    public int attack = 1;
    private bool on = false;
    private Animator anim;
    void Start()
    {
        this.anim = GetComponent<Animator>();
        StartCoroutine(DelayCoroutine());
    }

    private IEnumerator DelayCoroutine()
    {
        // 3•bŠÔ‘Ò‚Â
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && on)
        {
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null)
            {
                damageTarget.Damage(attack);
            }
        }
    }
}
