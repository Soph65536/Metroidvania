using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour
{
    const float jetpackForce = 3f;
    const float maxJetpackMeter = 2000f;

    private float jetpackMeter;
    public bool isJetpacking;

    //animator and rb script
    Animator animator;
    Rigidbody2D rb;

    //other player scripts
    PlayerMovement PlayerMovement;
    DeathScript DeathScript;
    Boomerang Boomerang;

    private void Start()
    {
        //set jetpack meter to intiially be max
        jetpackMeter = maxJetpackMeter;

        //set animator and rb script
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //set other player scripts
        PlayerMovement = GetComponent<PlayerMovement>();
        DeathScript = GetComponent<DeathScript>();
        Boomerang = GetComponent<Boomerang>();
    }

    private void Update()
    {
        //refill jetpack meter if not using jetpack and is not at max
        if(PlayerMovement.onGround && !isJetpacking && jetpackMeter<maxJetpackMeter) { jetpackMeter++; }

        if (!DeathScript.isDead && !Boomerang.currentlyBoomering && jetpackMeter>0 && Input.GetKey(KeyCode.X))
        {
            //set to jetpacking
            isJetpacking = true;
            animator.SetFloat("Jetpacking", 1);

            //decrement jetpack meter
            jetpackMeter--;

            //move player up
            rb.velocity = new Vector3(0, jetpackForce, 0);
        }
        else
        {
            //set to not jetpacking
            isJetpacking = false;
            animator.SetFloat("Jetpacking", 0);
        }
    }
}
