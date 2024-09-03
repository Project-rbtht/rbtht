using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    GameObject playerObj;
<<<<<<< HEAD
    public ground_judge groundJudge;
=======
    public GroundJudge groundJudge;
>>>>>>> origin/player
    public float smoothness = 1;

    float y;

    //PlayerController player;
    Transform playerTrans;
    void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        //player = playerObj.GetComponent<PlayerController>();
        playerTrans = playerObj.transform;
        y = playerTrans.position.y;
        smoothness = smoothness / 1000;
    }

    void LateUpdate() {
        y = transform.position.y;
        /*
        if (groundJudge.onGround == true) {
            if (Mathf.Abs(y - playerTrans.position.y) < smoothness) {
                y = playerTrans.position.y;
            } else {
                y += smoothness * Mathf.Sign(playerTrans.position.y - y);
            }
        }
        */
        transform.position = new Vector3(playerTrans.position.x, y, transform.position.z);
    }
}
