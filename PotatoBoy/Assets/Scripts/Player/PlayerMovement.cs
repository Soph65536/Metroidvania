using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //constants
    const float deathdelay = 1f;
    const float respawndelay = 1.75f;

    const float moveForce = 5f;
    const float jumpForce = 10f;

    //variables
    private bool isDead;

    private float horizontalInput;
    private float verticalInput;
    public bool onGround;

    Animator animator;
    Rigidbody2D rb;

    void Start()
    {
        //define animator
        animator = GetComponent<Animator>();
        //define rigidbody
        rb = transform.GetComponent<Rigidbody2D>();

        //setting initial variables
        isDead = false;

        horizontalInput = 0;
        verticalInput = 0;
        onGround = false;

        //set animator to play respawn on start
        animator.SetTrigger("PlayerRespawn");
    }


    void FixedUpdate()
    {
        //only allow player to be controlled when not dead
        if (!isDead)
        {
            //movement
            if (Input.GetKey(KeyCode.Space) && onGround)
            {
                //jump
                rb.velocity = new Vector3(0, jumpForce, 0);
            }

            //get input axis raw
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            //set animator parameters
            animator.SetFloat("horizontal", horizontalInput);
            animator.SetFloat("vertical", verticalInput);
        }
    }


    //kill player coroutine
    public IEnumerator KillPlayer()
    {
        isDead = true;

        //play death animation and wait for player death delay
        animator.SetTrigger("PlayerDeath");
        yield return new WaitForSeconds(deathdelay);

        //respawn player and wait for respawn animation
        transform.position = GameManager.Instance.SpawnPosition;
        animator.SetTrigger("PlayerRespawn");
        yield return new WaitForSeconds(respawndelay);

        isDead = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if collided with ground or checkpoint and not falling then grounded is true
        //else is false
        if ((collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Checkpoint")
            && (rb.velocity.y > -00.1 && rb.velocity.y < 0.01))
        {
            onGround = true;
            animator.SetBool("onGround", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //reset grounded since not colliding with anything
        onGround = false;
        animator.SetBool("onGround", false);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        //if collided with enemy go to startingpos
        if (collider.gameObject.tag == "Enemy" && !isDead)
        {
            StartCoroutine("KillPlayer");
        }
    }
}
