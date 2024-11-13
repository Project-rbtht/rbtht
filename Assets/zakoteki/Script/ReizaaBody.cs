using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReizaaBody : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        transform.root.gameObject.GetComponent<reizaa>().BodyDamage(collision);
    }
}
