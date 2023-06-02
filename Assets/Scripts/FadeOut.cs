using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public Animator Fade;
    private int nextScene;
    
    
  
    void OnTriggerStay(Collider other)
    {
        

        if (other.tag == "Player")
        {

            FadetoNext();
            
           
        }

    }
    public void FadetoNext()
    {
        Fadeout(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Fadeout(int levelIndex)
    {
        nextScene = levelIndex;
        Fade.SetTrigger("FadeOut");
    }
    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(nextScene);
    }

}
