using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explain : MonoBehaviour
{
    public GameObject matome;
    bool stop = false;

    void Update()
    {
        if (!stop && Time.timeScale == 0) {
            matome.SetActive(false);
            stop = true;
        } else if (stop && Time.timeScale != 0) {
            matome.SetActive(true);
            stop = false;
        }
    }
}
