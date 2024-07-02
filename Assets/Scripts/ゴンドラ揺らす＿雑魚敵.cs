using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ゴンドラ揺らす＿雑魚敵 : MonoBehaviour
｛
    
    public enum State Type
    {
        UNDEFIND,
        IDLE,
        MOVE,
        ATTACK,
        DEFENCE,
        DEAD,
    }

void Start()  // Start is called before the first frame update
    {
        
    }

    void OnTriggerEnter (Collider ぶつかったもの)
     {
        if(ぶつかったもの.gameObject.tag == "Player")
        {
            
           

        }
    　｝


    // Update is called once per frame
    void Update()
    {
       
    }
　}


