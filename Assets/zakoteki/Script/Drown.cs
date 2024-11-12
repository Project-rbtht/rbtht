using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drown : MonoBehaviour
{
public GameObject Bullet;


  public float _shotTime;
  public float _moveSpeed;
  private Rigidbody2D _rigid;
  private Vector2 _moveDirection;
     void Start()
     {
        InvokeRepeating("Shot", 1, _shotTime);

        _rigid = GetComponent<Rigidbody2D>();
        _moveDirection = Vector2.left;
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

   void Shot()
   {
    GameObject Bullets = Instantiate(Bullet.gameObject, transform.position, transform.rotation);
   }
}