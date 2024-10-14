using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    const float movingSpeed = 3.5f;

    [SerializeField] private Vector3 position1;
    [SerializeField] private Vector3 position2;

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

        //sets target position based on moving to pos 2
        targetPosition = movingToPos2 ? position2 : position1;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movingSpeed * Time.deltaTime);

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
