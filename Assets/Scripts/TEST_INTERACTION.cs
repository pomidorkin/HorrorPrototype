using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TEST_INTERACTION : MonoBehaviour
{
    [SerializeField] private PlayerActions playerActions;

    private void OnEnable()
    {
        playerActions.OnInteractedAction += CheckInteracted;
    }

    private void OnDisable()
    {
        playerActions.OnInteractedAction -= CheckInteracted;
    }

    private void CheckInteracted(RaycastHit hit)
    {
        if (hit.transform == this.transform)
        {
            Debug.Log("I am the cube and I am being interacted with...");
        }
    }
}
