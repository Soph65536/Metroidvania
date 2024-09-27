using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    //constants
    const float deathdelay = 1f;
    const float respawndelay = 1.75f;

    //variables
    Animator animator;

    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        //define animator
        animator = GetComponent<Animator>();

        isDead = false;
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //if collided with enemy go to startingpos
        if (collider.gameObject.tag == "Enemy" && !isDead)
        {
            StartCoroutine("KillPlayer");
        }
    }
}
