using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Damage_Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    IEnumerator DeleteTime()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

    public void DeleteEffect()
    {
        Destroy(gameObject);
    }
}
