using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public int damage = 1;
    public int recastTime = 1;
    public float time_explo = 0.5f;
    AudioSource audioSource;
    public AudioClip[] sounds;

  void  Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Explosion());
    }

IEnumerator Explosion()
{
    yield return null;
    audioSource.PlayOneShot(sounds[0]);
    yield return new WaitForSeconds(time_explo);
    Destroy(this.gameObject);
}


   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null) 
            {
                damageTarget.Damage(damage);
            }
    }
    }
}
