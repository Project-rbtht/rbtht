using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float speed = 0.1f;

    // Update is called once per frame
    void Update() {

        float posX, posY;

        posX = transform.position.x;
        posY = transform.position.y;

        if (Input.GetKey(KeyCode.D) == true) {
            posX += speed;
        }

        if (Input.GetKey(KeyCode.A) == true) {
            posX -= speed;
        }

        if (Input.GetKey(KeyCode.W) == true) {
            posY += speed;
        }

        if (Input.GetKey(KeyCode.S) == true) {
            posY -= speed;
        }

        transform.position = new Vector3(posX, posY, 0);
    }
}
