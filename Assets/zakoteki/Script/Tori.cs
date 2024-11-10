using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tori : MonoBehaviour
{
    private bool _detect;
    private bool _go;
    private bool _ready;
    private Animator _anim;
    private Rigidbody2D _rigid;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _detect = false;
        _anim.SetBool("detect", _detect);
        _go = false;
        _anim.SetBool("go", _go);
        _ready = false;
        _anim.SetBool("ready", _ready);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
