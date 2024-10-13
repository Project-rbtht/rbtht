using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour, Idamagable
{
    public int healthPoint = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Damage(int value)
    {
        healthPoint -= value;
        UnityEngine.Debug.Log("on Damage");

            
    }

    public void Death()
    {
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
