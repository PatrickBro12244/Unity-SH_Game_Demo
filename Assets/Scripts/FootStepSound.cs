using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSound : MonoBehaviour
{

 
    [SerializeField] private AudioSource FootSoundHard;
  

    public void StepSound()
    {
      
        FootSoundHard.volume = Random.Range(0.04f, 0.06f);
        //FootSoundHard.pitch = Random.Range(0.8f, 1f);
        FootSoundHard.Play();

    }

}
