using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FadeMov : MonoBehaviour
{
    public NavMeshAgent enemy;
    public CharacterMovement player;
    public Animator enemyanim;
    public bool inside = false;
    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            inside = true;
           


        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inside)
        {

            if (Input.GetKey(KeyCode.E))
            {
                enemyanim.speed = 0f;
                enemy.velocity = Vector3.zero;
                enemy.Stop(true);
                player.tankControls = false;
            }
        }
    }
}
