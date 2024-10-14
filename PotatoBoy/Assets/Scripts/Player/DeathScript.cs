using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    //constants
    const float startspawntime = 7.4f;
    const float deathdelay = 1f;
    const float respawndelay = 1.1f;

    //audio
    [SerializeField] private AudioSource gameMusic;

    //variables
    Animator animator;

    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        //define animator
        animator = GetComponentInParent<Animator>();

        isDead = false;

        StartCoroutine("SpawnPlayerControlsPrevention");
    }

    //kill player coroutine
    public IEnumerator KillPlayer()
    {
        isDead = true;

        //play death animation and wait for player death delay
        animator.SetTrigger("PlayerDeath");
        yield return new WaitForSeconds(deathdelay);

        //respawn player and wait for respawn animation
        transform.parent.position = GameManager.Instance.SpawnPosition;
        animator.SetTrigger("PlayerRespawn");
        yield return new WaitForSeconds(respawndelay);

        isDead = false;
    }

    public IEnumerator SpawnPlayerControlsPrevention()
    {
        //sets player as dead at start of the game
        //so they cant use the controls whilst the start cutscene plays

        isDead=true;

        yield return new WaitForSeconds (startspawntime);
        gameMusic.Play();

        isDead=false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //if collided with enemy go to startingpos
        if (collider.gameObject.CompareTag("Enemy") && !isDead)
        {
            StartCoroutine("KillPlayer");
        }
    }
}
