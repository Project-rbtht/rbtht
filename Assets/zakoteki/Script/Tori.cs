using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tori : MonoBehaviour
{
    private bool _detect;
    private bool _go;
    private bool _ready;
    private bool _tired;
    private bool _onFloor;
    public float _readySpeed;
    public float _readyTime;
    public float _byGoTime;
    public float _chaseSpeed1;
    public float _chaseSpeed2;
    public float _goSpeed;
    public float _tiredTime;
    public float _gondoraSpeed;
    private Animator _anim;
    private Rigidbody2D _rigid;
    private Transform playerPos;
    public GameObject player;
    private Vector2 _moveDirection;

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
        _tired = false;
        _anim.SetBool("tired", _tired);
        _onFloor = false;

        player = GameObject.Find("PlayerObject");
        playerPos = player.transform;
        _moveDirection = Vector2.left;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            _onFloor = true;
            _Move();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_detect)
        {
            _detect = true;
            _anim.SetBool("detect", _detect);
           StartCoroutine(Ready());
        }
    }
        IEnumerator Ready()
    {
        
        yield return new WaitForSeconds(0.3f);
        
        float elapsedTime = 0f;
        while (elapsedTime < _readyTime)
        {
            _rigid.velocity = new Vector2(_moveDirection.x * _chaseSpeed1, -_readySpeed + _gondoraSpeed); //斜めに突っ込む
            elapsedTime += Time.deltaTime; // 経過時間を加算
            yield return null; // 次のフレームを待つ
        }
        _rigid.velocity = Vector2.zero; // 停止

        _ready = true;
        _anim.SetBool("ready",_ready);
        float elapsedTime2 = 0f;
        while (elapsedTime2 < _byGoTime)
        {
            _rigid.velocity = new Vector2(_moveDirection.x * _chaseSpeed2, _gondoraSpeed); //追いかける
            elapsedTime2 += Time.deltaTime; // 経過時間を加算
            yield return null; // 次のフレームを待つ
        }
         
        _go = true;
        _anim.SetBool("go",_go);
        float elapsedTime3 = 0f;
        while (elapsedTime3 < 0.5f)
        {
            _rigid.velocity = new Vector2(0, -1 + _gondoraSpeed); // 下に移動(突っ込む前隙)
            elapsedTime3 += Time.deltaTime; // 経過時間を加算
            yield return null; // 次のフレームを待つ
        } 
        float elapsedTime4 = 0f;
        while (elapsedTime4 < 1.0f)
        {
            _rigid.velocity = new Vector2(0, _goSpeed + _gondoraSpeed); // 上に突っ込む
            elapsedTime4 += Time.deltaTime; // 経過時間を加算
            yield return null; // 次のフレームを待つ
        }

        _tired = true;
        _anim.SetBool("tired",_tired);
        float elapsedTime5 = 0f;
        while (elapsedTime5 < (-_readySpeed * _readyTime - 0.5f + _goSpeed)/3f)
        {
            _rigid.velocity = new Vector2(0, -3 + _gondoraSpeed); // 元の位置に移動
            elapsedTime5 += Time.deltaTime; // 経過時間を加算
            yield return null; // 次のフレームを待つ
        }

        _rigid.velocity = Vector2.zero;
          float elapsedTime6 = 0f;
        while (elapsedTime6 < _tiredTime)
        {
            _rigid.velocity = new Vector2(0, _gondoraSpeed); // 後隙
            elapsedTime6 += Time.deltaTime; // 経過時間を加算
            yield return null; // 次のフレームを待つ
        }

        _detect = false;
        _anim.SetBool("detect", _detect);
        _go = false;
        _anim.SetBool("go", _go);
        _ready = false;
        _anim.SetBool("ready", _ready);
        _tired = false;
        _anim.SetBool("tired", _tired);

    }

    // Update is called once per frame
    void Update()
    {
         FlipToPlayer();  
         
        
    }
    
    void FlipToPlayer()
 {
  if(player.transform.position.x < transform.position.x)
  {
    transform.rotation = Quaternion.Euler(0,0,0);
    _moveDirection = Vector2.left;
  }
  if(player.transform.position.x > transform.position.x)
  {
    transform.rotation = Quaternion.Euler(0,180,0);
    _moveDirection = Vector2.right;
  }
  if(player.transform.position.x - 0.08f < transform.position.x && transform.position.x <  player.transform.position.x + 0.08f)
  {
    _moveDirection = Vector2.zero;
  }
 }

  void _Move()
     { if(_onFloor)
     {
       _rigid.velocity = new Vector2(_rigid.velocity.x, _rigid.velocity.y  + _gondoraSpeed);
     }
     }


    
}
