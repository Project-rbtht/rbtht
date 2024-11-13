using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dossun : MonoBehaviour
{
    public float _fallSpeed = 10f;  // 落下速度
    public float _riseSpeed = 5f;    // 上昇速度
    public float _upTime = 3f;  //上昇時間
    private Rigidbody2D _rigid;
    private Animator _anim;

    private bool _detect;
    private bool _falled;

    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _detect = false;
        _anim.SetBool("detect", _detect);
        _falled = false;
        _anim.SetBool("falled", _falled);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_detect)
        {
            _rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
            _rigid.velocity = new Vector2(0, -_fallSpeed); // 落下開始
           // Debug.Log("detect");
            _detect = true;
            _anim.SetBool("detect", _detect);
            // コルーチンを呼び出さないようにする
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") && _detect && !_falled)
        {
            StartCoroutine(HandleFalling());
        }
    }

    private IEnumerator HandleFalling()
    {
        // 床に衝突した時にのみ_falledをtrueにする
        _falled = true;
        _anim.SetBool("falled", _falled);
        _rigid.velocity = Vector2.zero; // 停止

        // 1秒待つ
        yield return new WaitForSeconds(1.0f);

        // 3秒間上昇させる
        float elapsedTime = 0f;
        while (elapsedTime < _upTime)
        {
            _rigid.velocity = new Vector2(0, _riseSpeed); // 上に移動
            elapsedTime += Time.deltaTime; // 経過時間を加算
            yield return null; // 次のフレームを待つ
        }

        // 上昇が終了したら停止
        _rigid.velocity = Vector2.zero;
        _rigid.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
        _detect = false;
        _falled = false;
        _anim.SetBool("detect", _detect);
        _anim.SetBool("falled", _falled);
    }
}
