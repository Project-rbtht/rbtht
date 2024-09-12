using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : BossBase
{
    public GameObject bullet;
    private float laserLength = 20;
    private bool open = false;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        this.anim = GetComponent<Animator>();
        StartCoroutine(ChooseAction());
        //StartCoroutine(LaserSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Open", open);
    }

    private IEnumerator LaserSpawn()//頭の向き（transform.right）にレーザーを放つ
    {
        open = true;
        yield return new WaitForSeconds(0.5f);
        Instantiate(bullet, transform.position + laserLength * transform.right, transform.rotation);
        yield return new WaitForSeconds(4.5f);
        open = false;
        yield return new WaitForSeconds(1);
        StartCoroutine(ChooseAction());
    }

    private IEnumerator ChooseAction()
    {
        //LaserSpawn();
        StartCoroutine(LaserSpawn());
        yield return new WaitForSeconds(0);
    }
}
