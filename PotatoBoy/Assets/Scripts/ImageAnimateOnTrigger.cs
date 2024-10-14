using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAnimateOnTrigger : MonoBehaviour
{
    //sound
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    //animation
    [SerializeField] private Animator ImageAnimator;
    [SerializeField] private string AnimatorTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(audioClip);
            ImageAnimator.SetTrigger(AnimatorTrigger);
            Destroy(gameObject);
        }
    }
}
