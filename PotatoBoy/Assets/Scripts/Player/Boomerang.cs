using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    const float boomerangTime = 0.85f;


    public Animator playeranimator;
    public Animator boomeranganimator;

    DeathScript DeathScript;

    public bool currentlyBoomering;

    // Start is called before the first frame update
    void Start()
    {
        DeathScript = GetComponent<DeathScript>();
        currentlyBoomering = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!DeathScript.isDead && !currentlyBoomering && GameManager.Instance.gotBoomerang && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine("doBoomerang");
        }
    }

    public IEnumerator doBoomerang()
    {
        currentlyBoomering = true;

        float facingRight = playeranimator.GetFloat("facingRight");

        //trigger animation based on which way the player is facing
        if(facingRight < 0f)
        {
            playeranimator.SetTrigger("BoomerangLeft");
            boomeranganimator.SetTrigger("BoomerangLeft");
        }
        else
        {
            playeranimator.SetTrigger("BoomerangRight");
            boomeranganimator.SetTrigger("BoomerangRight");
        }

        yield return new WaitForSeconds(boomerangTime);

        currentlyBoomering = false;
    }
}
