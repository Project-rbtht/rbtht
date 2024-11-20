using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class Colliders {
    public Vector2 normalVector;
    public Collision2D collision;
}

public class FootScript : MonoBehaviour{
    public bool onGround = false;
    public Vector2 groundVector = Vector2.zero;
    public Vector2 preGroundVector = Vector2.zero;
    public Vector2 normalVector = Vector2.zero;
    public bool contactFloor = false;
    public bool onWall = false;
    bool exit = false;
    Rigidbody2D rb;
    //bool fin = false;
    float x = 0;
    float speedY = 0;
    bool jp = false;
    bool justJp = false;
    public IsWallScript isWallScript;
    public IsWallScript isSlopeScript;
    public IsWallScript onGroundScript;

    public PlayerScript playerScript;
    Animator anim = null;
    //List<Colliders> collisions = new List<Colliders>();
    List<Collision2D> collisions = new List<Collision2D>();
    List<Vector2> normals = new List<Vector2>();


    void Start() {
        anim = playerScript.gameObject.GetComponent<Animator>();
        rb = playerScript.gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        for(int i = 0; i < collision.contacts.Length; i++){
            collisions.Add(collision);
            normals.Add(collision.contacts[i].normal);
        }
        //a.collision = collision;
        //a.normalVector = collision.contacts[0].normal;
        //collisions.Add(a);


        //contactFloor = true;
        //if (collision.gameObject.tag == "Floor") {
        //    groundVector = Vector2.Perpendicular(collision.contacts[0].normal);
        //    if (groundVector.x != 0 && Mathf.Abs(groundVector.y / groundVector.x) <= 1) {
        //        onGround = true;
        //        playerScript.jpNum = playerScript.jpNumMax;
        //        anim.SetInteger("Jump", 0);
        //        anim.SetTrigger("Ground");
        //    }
        //}
    }

    void OnCollisionStay2D(Collision2D collision) {
        // int index = collisions.IndexOf(collision);
        // if (index >= 0) {
        //     normals.RemoveAt(index);
        //     collisions.RemoveAt(index);
        for(int i = 0; i < collision.contacts.Length; i++){
            collisions.Add(collision);
            normals.Add(collision.contacts[0].normal);
        }
        // }

        //if (fin) {
        //    fin = false;
        //    collisions.Clear();
        //}
        //Colliders a = new();
        //a.collision = collision;
        //a.normalVector = collision.contacts[0].normal;
        //collisions.Add(a);

        //if (collision.gameObject.tag == "Floor") {
        //contactFloor = true;
        //normalVector = collision.contacts[0].normal;
        //groundVector = Vector2.Perpendicular(normalVector);
        //if (groundVector.x != 0 && Mathf.Abs(groundVector.y / groundVector.x) <= 1) {
        //    if (playerScript.justJump) {
        //        playerScript.justJump = false;
        //    } else {
        //    onGround = true;
        //    playerScript.jpNum = playerScript.jpNumMax;
        //        if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Air")) {
        //            anim.SetInteger("Jump", 0);
        //            anim.SetTrigger("Ground");
        //        }
        //    }
        //} else {
        //    onGround = false;
        //    groundVector = Vector2.zero;
        //}
        //} else {
        //    groundVector = Vector2.zero;
        //    onGround = false;
        //}
    }

    private void OnCollisionExit2D(Collision2D collision) {
        //if (collision.gameObject.tag == "Floor") {
            // int index = collisions.IndexOf(collision);
            // if (index >= 0) {
            //     normals.RemoveAt(index);
            //     collisions.RemoveAt(index);
            // }

            //collisions.Remove(collision);
            exit = true;
            Debug.Log("exit");

            //        contactFloor = false;
            //        if (collision.gameObject.tag == "Floor" && groundVector.x != 0 && Mathf.Abs(groundVector.y / groundVector.x) <= 1.5) {
            //            onGround = false;
            //            groundVector = Vector2.zero;
            //            normalVector = Vector2.zero;
            //            playerScript.jpNum = playerScript.jpNumMax - 1;
            //            anim.SetInteger("Jump", 1);
            //        }
        //}
    }

    private void Update() {

        //foreach (Colliders collision in collisions) {
        //    if (collision.collision.gameObject.CompareTag("Floor")) {
        //        normalVector = collision.normalVector;
        //        if (normalVector.y != 0 && Mathf.Abs(normalVector.x / normalVector.y) <= 1) {
        //            if (playerScript.justJump) {
        //                playerScript.justJump = false;
        //            } else {
        //                onGround = true;
        //                playerScript.jpNum = playerScript.jpNumMax;
        //                if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Air")) {
        //                    anim.SetInteger("Jump", 0);
        //                    anim.SetTrigger("Ground");
        //                }
        //                groundVector = Vector2.Perpendicular(normalVector);
        //            }
        //        } else {
        //            onWall = true;
        //        }
        //    }
        //}

        //if (exit && !onGround) {
        //    playerScript.jpNum = playerScript.jpNumMax - 1;
        //    anim.SetInteger("Jump", 1);
        //}

        //fin = true;

        /////////////////////////////////////////////////////////////////////////////////////////////
        x = Input.GetAxisRaw("Horizontal");
        // speedY = rb.velocity.y;

        if(playerScript.canMove){
            if (speedY < 0 && !onGround) {
                anim.SetInteger("Jump", -1);
            }

            if (Input.GetButtonDown("Jump") == true) {
                jp = true;
                //if (playerScript.jpNum > 0) {
                //    speedY = playerScript.jpSpeed;
                //    if (onGround == true) {
                //        //if (groundJudge.onGround == true) {
                //        playerScript.justJump = true;
                //        anim.SetInteger("Jump", 1);
                //        playerScript.audioSource.PlayOneShot(playerScript.sounds[0]);
                //        onGround = false;
                //        playerScript.sakamichi = false;
                //        collisions.Clear();
                //        normals.Clear();
                //    } else {
                //        anim.SetInteger("Jump", 2);
                //        playerScript.audioSource.PlayOneShot(playerScript.sounds[1]);
                //    }
                //    playerScript.jpNum--;
                //}
            }

            anim.SetInteger("Speed", (int)Mathf.Abs(x * 2));

            // Direction
            if (x != 0) {
                playerScript.transform.localScale = new Vector3(x / Mathf.Abs(x), 1, 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.M)) {
            Debug.Log(collisions.Count);
            Debug.Log(normals.Count);
        }
    }

    private void FixedUpdate() {
        if(rb.gravityScale != 0){
            rb.gravityScale = 0;
        }
        if(justJp){
            collisions.Clear();
            normals.Clear();
            justJp = false;
        }
        if(!isWallScript.isWall){
            onWall = false;
        }
        if(!onGroundScript.isWall){
            onGround = false;
        }

        for (int i = 0; i < normals.Count; i++) {
            //if (collisions[i].gameObject.CompareTag("Floor")) {
            normalVector = normals[i];
            if (normalVector.y != 0 && Mathf.Abs(normalVector.x / normalVector.y) <= 1.5) {
                if (playerScript.justJump) {
                    playerScript.justJump = false;
                } else {
                    onGround = true;
                    playerScript.jpNum = playerScript.jpNumMax;
                    if (anim.GetCurrentAnimatorStateInfo(0).IsTag("Air")) {
                        anim.SetInteger("Jump", 0);
                        anim.SetTrigger("Ground");
                    }
                    groundVector = Vector2.Perpendicular(normalVector);
                }
            } else {
                onWall = true;
            }
            //}
        }

        if (!onGround && playerScript.sakamichi) {
            speedY = 0;
            playerScript.sakamichi = false;
        }

        if(playerScript.canMove){
            if (jp) {
                if (playerScript.jpNum > 0) {
                    speedY = playerScript.jpSpeed;
                    if (onGround == true) {
                        //if (groundJudge.onGround == true) {
                        playerScript.justJump = true;
                        anim.SetInteger("Jump", 1);
                        playerScript.audioSource.PlayOneShot(playerScript.sounds[0]);
                        onGround = false;
                        playerScript.sakamichi = false;
                        collisions.Clear();
                        normals.Clear();
                        Debug.Log("ground jump");
                    } else {
                        anim.SetInteger("Jump", 2);
                        playerScript.audioSource.PlayOneShot(playerScript.sounds[1]);
                        Debug.Log("air jump:"+playerScript.jpNum);
                    }
                    playerScript.jpNum--;
                }
                jp = false;
                justJp = true;
            }


            if (playerScript.jpNum == playerScript.jpNumMax && onGround) {
                // rb.gravityScale = 0;
                // rb.velocity = playerScript.speed * groundVector * Mathf.Sign(groundVector.x) * x;
                playerScript.sakamichi = true;
                if(!isSlopeScript.isWall && isWallScript.isWall){
                    rb.gravityScale = 0.1f;
                    Vector2 vectorA = GroundVector(rb.position + new Vector2(GetComponent<CircleCollider2D>().radius,0), new Vector2(0, -1), 10);
                    rb.MovePosition(rb.position + playerScript.speed * vectorA * Mathf.Sign(vectorA.x) * x * Time.deltaTime);
                    Debug.Log(0);
                }else{
                    if(groundVector == Vector2.zero){
                        groundVector = preGroundVector;
                    }
                    rb.MovePosition(rb.position + playerScript.speed * groundVector * Mathf.Sign(groundVector.x) * x * Time.deltaTime);
                    Debug.Log(1);
                }
            } else {
                // rb.gravityScale = playerScript.gravityScale;
                speedY -= 9.8f * playerScript.gravityScale * Time.deltaTime;
                if ((onWall && Mathf.Sign(normalVector.x) != x) || (playerScript.collide && Mathf.Sign(normalVector.x) != x)) {
                    // if(speedY == 0){
                    //     // rb.velocity = new Vector2(0, playerScript.speed / 100);
                    // } else {
                        // rb.velocity = new Vector2(0, speedY);
                        rb.MovePosition(rb.position + (new Vector2(0, speedY))*Time.deltaTime);
                    // }
                    // Debug.Log("jpNum:" + playerScript.jpNum + "onGround:" + onGround);
                    // Debug.Log("onWall & isWall" + onWall + isWallScript.isWall);
                    // Debug.Log("Sign" + (Mathf.Sign(normalVector.x) != x));
                    // Debug.Log("collide" + (playerScript.collide));
                } else { //jump
                    // rb.velocity = new Vector2(x * playerScript.speed, speedY);
                    rb.MovePosition(rb.position + (new Vector2(x * playerScript.speed, speedY))*Time.deltaTime);
                    Debug.Log(2);
                }
            }
        }

        collisions.Clear();
        normals.Clear();
        normalVector = Vector2.zero;
        preGroundVector = groundVector;
        groundVector = Vector2.zero;
    }

    Vector2 GroundVector(Vector2 pos, Vector2 dir, float dis){
        Vector2 slopeVector = Vector2.zero;
        RaycastHit2D hit = Physics2D.Raycast(pos, dir, dis);
        if(hit.collider != null){
            Vector2 normal = hit.normal;
            slopeVector = Vector2.Perpendicular(normal).normalized;
        }
        return slopeVector.normalized;
    }
}