using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Laser : MonoBehaviour
{
    // Start is called before the first frame update

    public int attack = 1;
    private bool before;
    private bool on = false;
    private Animator anim;
    public AudioClip audioClip;
    private AudioSource audioSource;

    void Start()
    {
        this.anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(DelayCoroutine());
    }

    private IEnumerator DelayCoroutine()
    {
        // 3�b�ԑ҂�
        yield return new WaitForSeconds(0.8f);
        on = true;
        yield return new WaitForSeconds(2);
        //audioSource.PlayOneShot(audioClip);
        on = false;
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        anim.SetBool("on", on);
    }

    public void BeforeLaser()
    {
        before = true;
    }

    public void OnLaser()
    {

        before = false;
        on = true;
    }

    public void EndLaser()
    {
        before = false;
        on = false;
    }


    void OnTriggerStay2D(Collider2D collision)
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
