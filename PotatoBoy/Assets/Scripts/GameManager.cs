using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //creates the gamemanager instance
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    //variables

    //player
    public Vector3 SpawnPosition;

    public SpriteRenderer boomerangRenderer;
    public bool gotBoomerang;

    void Awake()
    {
        //makes sure there is only one gamemanager instance and sets that instance to this
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        SpawnPosition = Vector3.zero;

        boomerangRenderer = GameObject.FindGameObjectWithTag("PlayerWeapon").GetComponentInChildren<SpriteRenderer>();
        boomerangRenderer.enabled = false;
        gotBoomerang = false;
    }
}
