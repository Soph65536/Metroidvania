using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JetpackUI : MonoBehaviour
{
    Jetpack Jetpack;

    private Slider jetpackBar;

    // Start is called before the first frame update
    void Start()
    {
        Jetpack = GameObject.FindGameObjectWithTag("Player").GetComponent<Jetpack>();
        jetpackBar = GetComponent<Slider>();
        jetpackBar.maxValue = Jetpack.maxJetpackMeter;
    }

    // Update is called once per frame
    void Update()
    {
        jetpackBar.value = Jetpack.jetpackMeter;
    }
}
