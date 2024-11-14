using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager_Boss1 : MonoBehaviour
{
    // Start is called before the first frame update

    private bool leftSnake = true;
    private bool rightSnake = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LeftSnakeDead()
    {
        leftSnake = false;
        Debug.Log("LeftSnakeDead");
        JuegeBothDead();
    }

    public void RightSnakeDead() {
        rightSnake = false;
        Debug.Log("RIghtSnakeDead");
        JuegeBothDead();
    }

    private void JuegeBothDead()
    {
        if(!leftSnake && !rightSnake)
        {
            Debug.Log("GameClear");
            SceneManager.LoadScene("ClearScene");
        }
    }
}
