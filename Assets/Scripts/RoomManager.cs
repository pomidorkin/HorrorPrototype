using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] GameObject[] rooms;
    private int testCounter = 0;

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (testCounter == 0)
            {
                foreach (GameObject room in rooms)
                {
                    room.gameObject.SetActive(false);
                }
                rooms[0].gameObject.SetActive(true);
                testCounter++;
            }
            else if (testCounter == 1)
            {
                foreach (GameObject room in rooms)
                {
                    room.gameObject.SetActive(false);
                }
                rooms[1].gameObject.SetActive(true);
                testCounter++;
            }
            else
            {
                foreach (GameObject room in rooms)
                {
                    room.gameObject.SetActive(false);
                }
                rooms[2].gameObject.SetActive(true);
                testCounter++;
            }
        }
    }
}
