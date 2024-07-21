using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject playerObj;
    //PlayerController player;
    Transform playerTransform;
    void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        //player = playerObj.GetComponent<PlayerController>();
        playerTransform = playerObj.transform;
    }

    void LateUpdate() {
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}
