using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zakoBeam : MonoBehaviour
{
   public int damage = 1;
    private bool on = false;
    private Animator anim;
    public int recastTime = 1;
    AudioSource audioSource;
    public AudioClip[] sounds;

    void Start()
    {
        this.anim = GetComponent<Animator>();
        StartCoroutine(DelayCoroutine());
        audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator DelayCoroutine()
    {
        yield return null;
        audioSource.PlayOneShot(sounds[0]);
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
