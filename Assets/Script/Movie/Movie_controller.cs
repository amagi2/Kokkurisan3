using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movie_controller : MonoBehaviour
{
    public GameObject Fade;         //FadeOut

    //FadeOutにてNextがTrueになったら次のシーンへ
    void Next_Scene()
    {
        if (Fade.GetComponent<Fade_Out>().Next == true)
        {
            SceneManager.LoadScene("StoryScene");
        }
    }

    void Start()
    {

    }

    void Update()
    {
        Next_Scene();
    }
}
