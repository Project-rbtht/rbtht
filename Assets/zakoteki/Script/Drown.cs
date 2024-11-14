using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drown : MonoBehaviour
{
public GameObject Bullet;


  public float _shotTime;
  public float _moveSpeed;
  private bool _detect;
  private Rigidbody2D _rigid;
  private Vector2 _moveDirection;
     void Start()
     {
        _detect = false;
        _rigid = GetComponent<Rigidbody2D>();
        _moveDirection = Vector2.left;
        StartCoroutine(Shot());
     }
     void Update()
     {
      
       _Move();
       _LookMoveDirection();
     }
      
       private void _Move()
     {
       _rigid.velocity = new Vector2(_moveDirection.x * _moveSpeed, _rigid.velocity.y);
     }
       void OnTriggerEnter2D(Collider2D collision)
     {
        
         if (collision.CompareTag("Floor"))
         {
          _moveDirection = -_moveDirection;
         }
         if(collision.CompareTag("Player"))
        {
         _detect = true;
        }

     }   
         private void _LookMoveDirection()
    {
    if (_moveDirection.x < 0.0f)
    {
        transform.localScale = new Vector3(-1, 1, 1);
    }
    else if (_moveDirection.x > 0.0f)
    {
        transform.localScale = new Vector3(1, 1, 1);
    }
}
   
   IEnumerator Shot()
   {
    while(!_detect)
    {
        yield return null;
    }
    while(_detect)
    {
   Instantiate(Bullet, transform.position, transform.rotation);
   yield return new WaitForSeconds(_shotTime);
   yield return null;
    }
    StartCoroutine(Shot());
   }

   void OnTriggerExit2D(Collider2D collision)
     {
         if (collision.CompareTag("Player"))
         {
          _detect = false;
         }
     }

}