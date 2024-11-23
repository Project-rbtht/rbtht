using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageJumpFloor : MonoBehaviour
{

    // Start is called before the first frame update
    private GameObject player;
    protected Rigidbody2D rigidbody2d;
    public int attack = 2;
    public float bounceForce = 3;
    void Start()
    {
        player = GameObject.Find("PlayerObject");
        if (player == null)
        {
            Debug.Log("player == null");
        }
        else
        {
            rigidbody2d = player.GetComponent<Rigidbody2D>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player!");
            var damageTarget = collision.gameObject.GetComponent<Idamagable>();
            if (damageTarget != null)
            {
                damageTarget.Damage(attack);
                Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
                if (playerRigidbody != null)
                {
                    // è„ï˚å¸Ç…óÕÇâ¡Ç¶ÇÈ
                    Debug.Log("AddForcePlayer");
                    playerRigidbody.AddForce(playerRigidbody.transform.up * bounceForce, ForceMode2D.Impulse);
                }
                else
                {
                    Debug.Log("rigidbodyÇ»Çµ");
                }
            }
        }
    }
}
