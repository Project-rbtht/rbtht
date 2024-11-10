using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronBallScript : MonoBehaviour
{
    public float speedX;
    public float speedY;
    public int damage = 0;
    public float direct = 1;
    public GameObject player;

    private void Start() {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(speedX*direct, speedY);
        StartCoroutine(Deny());
    }

    IEnumerator Deny() {
        yield return new WaitForSeconds(2.0f);
        Destroy(this.gameObject);
    }


    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null) {
                damageTarget.Damage(damage);
                player.GetComponent<PlayerScript>().Hit();
            }
        }
    }
}
