using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuriboHead : MonoBehaviour
{
    private GameObject player;
    private PlayerScript playerScript;
    public GameObject damageEffect;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerObject");
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerFoot")
        {
            playerScript.Hit();
            GameObject instantiatedObject =Instantiate(damageEffect,transform.position,transform.rotation);
            Destroy(this.gameObject.transform.parent.gameObject);
            
        }
    }

    
}
