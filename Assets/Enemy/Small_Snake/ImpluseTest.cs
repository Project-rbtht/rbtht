using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpluseTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb_sphere = this.GetComponent<Rigidbody2D>();
        rb_sphere.AddForce(transform.right * 10f, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Rigidbody2D rb_sphere = this.GetComponent<Rigidbody2D>();
            rb_sphere.AddForce(transform.right * 10f, ForceMode2D.Impulse);
        }

    }
}
