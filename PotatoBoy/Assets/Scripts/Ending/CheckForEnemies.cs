using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForEnemies : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <=1)
        {
            Destroy(gameObject);
        }
    }
}
