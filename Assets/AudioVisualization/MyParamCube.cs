using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyParamCube : MonoBehaviour
{
    [SerializeField] [Range(0, 7)] int band = 0;
    [SerializeField] [Range(0f, 10f)] float animTriggerValue = 1.6f;
    void Update()
    {
        // My Code
        if (AudioPeer.bandBuffer[band] > animTriggerValue)
        {
            // Commented out for testing
            //gameObject.GetComponent<Animator>().Play("SlammAnimation");
        }

    }
}