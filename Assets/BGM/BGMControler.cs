using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMControler : MonoBehaviour
{
    AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        //StartCoroutine(AfterStart());
    }

    //IEnumerator AfterStart() {
    //    yield return new WaitForSeconds(0.1f);
    //    UnPause();
    //}

    //private void FixedUpdate() {
    //    if (!audioSource.isPlaying) {
    //        UnPause();
    //    }
    //}

    public void UnPause() {
        audioSource.UnPause();
    }
    public void Pause() {
        audioSource.Pause();
    }
}
