using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsWallScript : MonoBehaviour
{
    public bool isWall = false;
    Collider2D collision = null;
    void OnTriggerEnter2D(Collider2D other) {
        collision = other;
    }

    private void OnTriggerStay2D(Collider2D other) {
        collision = other;
    }

    private void FixedUpdate() {
        if(collision != null){
            isWall = true;
            collision = null;
        } else {
            isWall = false;
        }
    }
}
