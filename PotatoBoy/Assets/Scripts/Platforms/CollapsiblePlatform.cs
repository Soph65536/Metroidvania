using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsiblePlatform : MonoBehaviour
{
    const float collapseDelay = 5f;

    private bool isCollapsing;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        isCollapsing = false;
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isCollapsing)
        {
            StartCoroutine("CollapsePlatform");
        }
    }

    private IEnumerator CollapsePlatform()
    {
        isCollapsing = true;

        animator.SetTrigger("Collapsing");
        yield return new WaitForSeconds(collapseDelay);

        isCollapsing = false;
    }
}
