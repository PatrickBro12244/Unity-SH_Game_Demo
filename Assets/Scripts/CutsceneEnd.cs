using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class CutsceneEnd : MonoBehaviour
{
    public Animator Fade;
    public VideoPlayer Cutscene;
    private int nextScene;



    void Awake()
    {
        Cutscene.Play();
        Cutscene.loopPointReached += FadetoNext;
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;


    }
    public void FadetoNext(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(nextScene);
    }
   

}