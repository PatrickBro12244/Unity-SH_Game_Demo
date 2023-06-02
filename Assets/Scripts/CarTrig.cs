using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrig : MonoBehaviour
{

    [SerializeField] private Animator car;
    [SerializeField] private AudioSource cars;
    private bool seen = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (!seen)
            {
                car.SetBool("PlayAnim", true);
                cars.Play();
                seen = true;
            }
            
        }
    }
}
