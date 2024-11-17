using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecastScript : MonoBehaviour
{
    [SerializeField] GameObject fader;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int attackNum;

    GameObject player;
    PlayerScript playerScript;
    GameObject attack;
    float recastTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
        attack = player.transform.Find("Attack" + attackNum).gameObject;
        recastTime = attack.GetComponent<Attack>().RecastTime();
    }

    // Update is called once per frame
    void Update() {
        if (!playerScript.attackActivated[attackNum]) {
            this.gameObject.SetActive(false);
        }
        float time = player.GetComponent<PlayerScript>().counter[attackNum];
        fader.GetComponent<Image>().fillAmount = time / attack.GetComponent<Attack>().RecastTime();
        if (time == recastTime) {
            text.enabled = true;
        } else if (time > 1) {
            text.text = Mathf.Floor(time).ToString();
        } else if (time >0){
            text.text = (Mathf.Ceil(time*10) / 10).ToString();
        } else {
            text.enabled = false;
        }
    }
}
