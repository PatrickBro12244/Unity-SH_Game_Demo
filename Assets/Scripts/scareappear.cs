using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scareappear : MonoBehaviour
{
    public GameObject gone;
    public GameObject Appear;
    public GameObject Taken;
    public AudioSource sound;
    // Start is called before the first frame update

    void Start()
    {
        Appear.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(gone == null)
        {
            Appear.SetActive(true) ;
            sound.Play();
        }
        if(Taken == null)
        {
            sound.Stop();
            Appear.SetActive(false);
        }
    }
}
