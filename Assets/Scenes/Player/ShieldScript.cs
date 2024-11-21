using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public void ShieldActive(bool value) {
        this.gameObject.SetActive(value);
    }

    public void JustShield(float time) {
        this.gameObject.GetComponent<Animator>().SetTrigger("justGuard");
        StartCoroutine(UpMode(time));
    }

    private void Update() {
        if (!this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Just") && !Input.GetButton("Guard")) {
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator UpMode(float time) {
        this.gameObject.GetComponent<Animator>().updateMode = AnimatorUpdateMode.UnscaledTime;
        yield return new WaitForSeconds(time);
        this.gameObject.GetComponent<Animator>().updateMode = AnimatorUpdateMode.Normal;
    }
}
