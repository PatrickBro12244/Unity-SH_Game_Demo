using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixedCam : MonoBehaviour
{

    public Transform player;
    public bool look = false;

    void Update()
    {
        if (look)
        {
            transform.LookAt(player);
        }
    }


}
