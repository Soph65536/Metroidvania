using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    const float EndCutsceneDelay = 10f;

    [SerializeField] private Animator ImageAnimator;
    private bool inEnding;

    private void Start()
    {
        inEnding = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("EndingGame");
        }
    }

    private IEnumerator EndingGame()
    {
        inEnding = true;
        ImageAnimator.SetTrigger("Ending");
        yield return new WaitForSeconds(EndCutsceneDelay);
        Debug.Log("End");
        Application.Quit();
    }
}
