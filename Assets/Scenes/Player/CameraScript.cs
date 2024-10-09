using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject playerObj;

    float y;

    //PlayerController player;
    Transform playerTrans;
    void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        playerTrans = playerObj.transform;
        y = playerTrans.position.y;
    }

    void LateUpdate() {
        y = transform.position.y;
        if (playerObj.GetComponent<PlayerScript>().gameOver) {
            transform.position = new Vector3(playerTrans.position.x, transform.position.y, transform.position.z);
        } else {
            transform.position = new Vector3(playerTrans.position.x, playerTrans.position.y, transform.position.z);
        }
    }
}
