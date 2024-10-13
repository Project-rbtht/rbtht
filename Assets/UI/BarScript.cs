using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScript : MonoBehaviour
{
    public float time;

    void Update()
    {
        Vector2 scale = transform.localScale;
        scale.x -= Time.deltaTime / time;
        if (scale.x < 0) {
            scale.x = 0;
            transform.localScale = scale;
            this.enabled = false;
        }
        transform.localScale = scale;
    }
}
