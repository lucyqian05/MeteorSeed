using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject exterior;
    public GameObject player;
    public float enterPositionX;
    public float enterPositionY;
    public float exitPositionX;
    public float exitPositionY;

    public void UseDoor()
    {
        if (exterior.activeInHierarchy == true)
        {
            exterior.SetActive(false);
            player.transform.position = new Vector3(enterPositionX, enterPositionY,0);

        } else
        {
            exterior.SetActive(true);
            player.transform.position = new Vector3(exitPositionX, exitPositionY, 0);
        }

    }
}
