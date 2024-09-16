using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FlyAndChase : EnemyBase
{
    
    public float speed = 2.0f;
    private GameObject player;
    private Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        player = GameObject.Find("PlayerObject");
        if (player == null)
        {
            Debug.Log("player == null");
        }
        playerPos = player.transform;
        StartCoroutine(ChasePlayer());
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }

    private IEnumerator ChasePlayer()
    {
        playerPos = player.transform;
        yield return new WaitForSeconds(3);
        StartCoroutine(ChasePlayer());
    }
}
