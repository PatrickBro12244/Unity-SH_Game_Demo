using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamera : MonoBehaviour
{
    public Transform player;
    public Transform face;
    public float smooth = 0.3f;
    public float height;
    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame


   
    void Update()
    {


        Vector3 pos = new Vector3();
        pos.x = player.position.x;
        pos.z = player.position.z - 7f;
        pos.y = player.position.y + height;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);


        /*  if(Input.GetKey(KeyCode.C))
          {
              ResetCam();

          }
          else 
          {
              Vector3 pos = new Vector3();
              pos.x = player.position.x;
              pos.z = player.position.z - 7f;
              pos.y = player.position.y + height;
              transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);

          }*/



    }


   /* public void ResetCam()
    {

        transform.position = face.position;
       

    }*/
}