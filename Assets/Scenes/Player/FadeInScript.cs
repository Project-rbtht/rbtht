using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeInrScript : MonoBehaviour
{
    float opasity = 0;
    Color color;
    float fadeTime = 2.0f;

    private void Start() {
        color = GetComponent<TextMeshProUGUI>().color;
    }

    void Update()
    {
        opasity += Time.deltaTime/fadeTime;
        if (opasity >= 1) {
            color.a = 1;
            GetComponent<TextMeshProUGUI>().color = color;
            this.enabled = false;
        }
        color.a = opasity;
        GetComponent<TextMeshProUGUI>().color = color;

    }
}
