using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Hit());
    }

    IEnumerator Hit()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }
}
