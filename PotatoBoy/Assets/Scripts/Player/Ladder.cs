using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    const float climbSpeed = 5;

    //variables
    private float verticalInput;
    private float PlayerGravityScale;
    private bool LadderOverlap;

    //animator and rb script
    Animator animator;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        verticalInput = 0;
        LadderOverlap = false;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        PlayerGravityScale = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");

        //climbing mode when overlap ladder
        if (LadderOverlap)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector3(0, verticalInput * climbSpeed, 0);
        }
        else
        {
            rb.gravityScale = PlayerGravityScale;
        }

        //animation
        if (verticalInput == 0)
        {
            animator.SetBool("isClimbing", false);
        }
        else
        {
            animator.SetBool("isClimbing", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            LadderOverlap = true;
            animator.SetBool("LadderOverlap", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            LadderOverlap = false;

            animator.SetBool("isClimbing", false);
            animator.SetBool("LadderOverlap", false);
        }
    }
}
