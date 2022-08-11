using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    [SerializeField] GameObject[] lights;
    public void ChangePosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public void TurnMyLightsOn(bool value)
    {

    }
}
