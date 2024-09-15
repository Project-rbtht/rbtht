using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FlyAndChase_Strait : EnemyBase
{
    
    public float moveTime = 2.0f;
    public float waitTime = 2.0f;
    private float speed;
    private GameObject player;
    /*[SerializeField]*/ private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerObject");
        if (player == null)
        {
            Debug.Log("player == null");
        }
        playerPos = player.transform.position;
        StartCoroutine(ChasePlayer());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
    }

    private IEnumerator ChasePlayer()
    {
        playerPos = player.transform.position;
        speed = Vector3.Distance(transform.position, playerPos) / moveTime;
        yield return new WaitForSeconds(moveTime + waitTime);
        StartCoroutine(ChasePlayer());
    }
}
