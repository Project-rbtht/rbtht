using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletreizaa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
public float speed = 0.1f;
    // Update is called once per frame
    void Update()
    {
          transform.position = transform.position + new Vector3 (1, 0, 0) * speed ;
    }
}
