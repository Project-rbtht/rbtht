using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamagedTriangleScript : MonoBehaviour
{
    public GameObject healthTriangle;
    public GameObject damagedBar;

    float decSpeed;

    private void Start() {
        decSpeed = damagedBar.GetComponent<DamagedBarScript>().decSpeed;
    }

    void Update() {
        Vector3 triPos = transform.localPosition;
        transform.localPosition = new Vector3(triPos.x - Time.deltaTime * decSpeed * damagedBar.GetComponent<RectTransform>().sizeDelta.x, triPos.y, 0);
        if (healthTriangle.transform.localPosition.x >= transform.localPosition.x) {
            transform.localPosition = new Vector3(healthTriangle.transform.localPosition.x, triPos.y, 0);
            this.enabled = false;
        }
    }
}
