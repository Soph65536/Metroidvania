using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    const float movingSpeed = 0.008f;

    [SerializeField] private Vector3 position1;
    [SerializeField] private Vector3 position2;

    private bool movingToPos2;

    AudioSource audioSource;
    [SerializeField] private AudioClip DeathSound;

    Animator animator;

    private void Start()
    {
        movingToPos2 = true;

        audioSource = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        AnimateEnemy();
    }

    //moving script
    private void Movement()
    {
        Vector3 targetPosition;

        //sets target position based on moving to pos 2
        targetPosition = movingToPos2 ? position2 : position1;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movingSpeed);

        if(transform.position == targetPosition) { movingToPos2 = !movingToPos2; }
    }

    private void AnimateEnemy()
    {
        if (movingToPos2) { animator.SetFloat("FacingRight", 1); }
        else { animator.SetFloat("FacingRight", -1); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerWeapon"))
        {
            audioSource.PlayOneShot(DeathSound);
            Destroy(gameObject);
        }
    }
}
