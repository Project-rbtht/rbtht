using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{

    public float time;

    // Update is called once per frame
    void Update()
    {
        Vector2 scale = transform.localScale;
        scale.x -= Time.deltaTime / time;
        scale.y -= Time.deltaTime / time;
        transform.localScale = scale;
    }
}
