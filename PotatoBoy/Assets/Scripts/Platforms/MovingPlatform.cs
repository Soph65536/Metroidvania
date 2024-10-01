using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    const float movingSpeed = 0.005f;

    public Vector3 position1;
    public Vector3 position2;

    private bool movingToPos2;

    private void Start()
    {
        movingToPos2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    //moving script
    private void MovePlatform()
    {
        Vector3 targetPosition;

        if (movingToPos2) { targetPosition = position2; }
        else { targetPosition = position1; }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movingSpeed);

        if(transform.position == targetPosition) { movingToPos2 = !movingToPos2; }
    }

    //attaches player to platform temporarily when colliding
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
