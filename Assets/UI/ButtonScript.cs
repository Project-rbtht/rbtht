using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public string preStage;

    // Start is called before the first frame update
    public void RestartButton() {
        SceneManager.LoadScene(preStage);
    }
    public void MenuButton() {
        SceneManager.LoadScene("menu");
    }
}
