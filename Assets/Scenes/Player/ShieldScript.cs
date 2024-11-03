using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public void ShieldActive(bool value) {
        this.gameObject.SetActive(value);
    }
}
