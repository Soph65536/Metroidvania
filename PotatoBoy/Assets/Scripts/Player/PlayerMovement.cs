using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //constants
    const float moveForce = 5f;
    const float jumpForce = 7f;

    //variables
    private float horizontalInput;
    private float facingRight;
    public bool onGround;

    Animator animator;
    Rigidbody2D rb;

    DeathScript DeathScript;
    Boomerang Boomerang;
    Jetpack Jetpack;

    void Start()
    {
        //spawn in the air above spawnposition
        transform.position = new Vector3(0, 6, 0);

        //define animator
        animator = GetComponent<Animator>();
        //define rigidbody
        rb = transform.GetComponent<Rigidbody2D>();

        //define other scripts
        DeathScript = GetComponentInChildren<DeathScript>();
        Boomerang = GetComponent<Boomerang>();
        Jetpack = GetComponent<Jetpack>();

        //setting initial variables
        horizontalInput = 0;
        facingRight = -1;
        onGround = false;
    }


    void FixedUpdate()
    {
        //only allow player to be controlled when not dead or boomering
        if (!DeathScript.isDead && !Boomerang.currentlyBoomering)
        {
            //movement
            if (!Jetpack.isJetpacking && Input.GetKey(KeyCode.Space) && onGround)
            {
                //jump
                rb.velocity = new Vector3(0, jumpForce, 0);
            }

            //get input axis raw
            horizontalInput = Input.GetAxisRaw("Horizontal");
            //move based on input
            transform.position += Vector3.right * horizontalInput * moveForce * Time.deltaTime;

            //set facing right based on last direction walked
            if (horizontalInput != 0) { facingRight = horizontalInput; }

            //set animator parameters
            animator.SetFloat("horizontal", horizontalInput);
            animator.SetFloat("facingRight", facingRight);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if collided with ground or checkpoint and not falling then grounded is true
        if ((collision.gameObject.CompareTag("Ground"))
            && (rb.velocity.y > -0.1 && rb.velocity.y < 0.1))
        {
            onGround = true;
            animator.SetFloat("onGround", 1);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //reset grounded since not colliding with anything
        onGround = false;
        animator.SetFloat("onGround", 0);
    }
}
