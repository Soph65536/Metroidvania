using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAnimateOnTrigger : MonoBehaviour
{
    [SerializeField] private Animator ImageAnimator;
    [SerializeField] private string AnimatorTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ImageAnimator.SetTrigger(AnimatorTrigger);
            Destroy(gameObject);
        }
    }
}
