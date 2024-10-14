using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    const float EndCutsceneDelay = 10f;

    [SerializeField] private Animator ImageAnimator;
    private bool inEnding;

    //audio
    [SerializeField] private AudioSource gameMusic;
    [SerializeField] private AudioSource playerAudio;
    [SerializeField] private AudioSource playerOneShotAudio;

    [SerializeField] private AudioClip endingAudio;

    private void Start()
    {
        inEnding = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !inEnding)
        {
            StartCoroutine("EndingGame");
        }
    }

    private IEnumerator EndingGame()
    {
        inEnding = true;

        //stop all music
        gameMusic.Stop();
        playerAudio.enabled = false;
        playerOneShotAudio.enabled = false;

        //player ending sound
        gameMusic.PlayOneShot(endingAudio);

        //play ending animation
        ImageAnimator.SetTrigger("Ending");
        yield return new WaitForSeconds(EndCutsceneDelay);

        //close game
        Debug.Log("End");
        Application.Quit();
    }
}
