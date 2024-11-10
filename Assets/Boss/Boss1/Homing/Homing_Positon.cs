using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_Position : MonoBehaviour
{
    private GameObject player;
    private Transform playerPos;
    public float speed = 10;//‘¬“x
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerObject");
        if (player == null)
        {
            Debug.Log("player == null");
        }
        playerPos = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }
}
