using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private PlatformEffector2D PlatformEffector;
    private float PlatformEffectorArc;

    private void Start()
    {
        PlatformEffector = GetComponent<PlatformEffector2D>();
        PlatformEffectorArc = PlatformEffector.surfaceArc;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            PlatformEffector.surfaceArc = 0f;
        }
        else
        {
            PlatformEffector.surfaceArc = PlatformEffectorArc;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlatformEffector.surfaceArc = PlatformEffectorArc;
    }
}
