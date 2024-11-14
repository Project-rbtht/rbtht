using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public GameObject targetObj = null;
    bool isGondora = false;

    //PlayerController player;
    Transform targetTrans;
    void Start() {
        if (targetObj == null) {
            targetObj = GameObject.FindGameObjectWithTag("Player");
        } else {
            isGondora = true;
        }
        targetTrans = targetObj.transform;
    }

    void LateUpdate() {
        if (!isGondora && targetObj.GetComponent<PlayerScript>().gameOver) {
            transform.position = new Vector3(targetTrans.position.x, transform.position.y, transform.position.z);
        } else {
            transform.position = new Vector3(targetTrans.position.x, targetTrans.position.y, transform.position.z);
        }
    }
}