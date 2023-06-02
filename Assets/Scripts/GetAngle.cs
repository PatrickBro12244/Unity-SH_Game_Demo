using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAngle : MonoBehaviour
{
    public Transform GameObject;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        float Rotation;
      
            Rotation = GameObject.eulerAngles.y;
      
          
      

        Debug.Log(Rotation);

    }
}
